using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using TALABAT.API.Helpers;
using TALABAT.CORE.Entities.Identity;
using TALABAT.CORE.Repository.Contract;
using TALABAT.REPOSITORY;
using TALABAT.REPOSITORY.Data;
using TALABAT.REPOSITORY.Identity;

namespace TALABAT.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {



            
            var builder = WebApplication.CreateBuilder(args);

            #region Configure  SERVICE
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingProfiles));

            builder.Services.AddDbContext<StoreContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddSingleton<IConnectionMultiplexer>(S =>
            {
                var connection = builder.Configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connection);
            });
            builder.Services.AddDbContext<AppIdentityDbcontext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {

            }).AddEntityFrameworkStores<AppIdentityDbcontext>();   /*  here you are allow the DI for IStore( a method in class Usermaneger ) 
            when we created (var userResult = await _userManager.CreateAsync(user, "Password@123");) 
           so to create or to do this method (CreateAsync) you have to allow Di for its Interface thta exists in Store in Istore Interface )
            */



            builder.Services.AddScoped (typeof(IGenaricRepository<>),typeof(GenaricRepository<>));
            builder.Services.AddScoped(typeof(IBasketRepo), typeof(BasketRepo));
            #endregion

            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var _dbcontext = services.GetRequiredService<StoreContext>();
            var _Identitydbcontext =  services.GetRequiredService<AppIdentityDbcontext>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbcontext.Database.MigrateAsync(); // Update Database

                await StoreContextSeed.SeedAsync(_dbcontext);

                await _Identitydbcontext.Database.MigrateAsync(); // Update Database

                var _userManager = services.GetRequiredService< UserManager < AppUser >>(); // Explicitly 
                await AppIdentitySeed.SeedUsersAsync( _userManager);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error has been accured during applying migration ");
            }




            #region cofigure kestrel middelwares
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();


            #endregion


            app.Run();
        }
    }
}
