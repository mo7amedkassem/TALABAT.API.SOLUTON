using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TALABAT.CORE.Entities.Identity;

namespace TALABAT.REPOSITORY.Identity
{
    public class AppIdentityDbcontext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbcontext(DbContextOptions<AppIdentityDbcontext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Adress>().ToTable("Adresses");
        }
    }
}
