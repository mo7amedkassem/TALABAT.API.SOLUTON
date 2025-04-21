using AutoMapper;
using TALABAT.API.Dtos;
using TALABAT.CORE.Entities;

namespace TALABAT.API.Helpers
{
    public class ProductPictureUrlIResolver : IValueResolver< Product, ProductReturnToDtos, string >
    {
        private readonly IConfiguration _configuration ;

        public ProductPictureUrlIResolver(IConfiguration configuration) {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductReturnToDtos destination, string  destMember, ResolutionContext context)
        {


            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configuration["ApiBaseUrl"]}/{source.PictureUrl}";

            return string.Empty ;
        }
    }
}
