using AutoMapper;
using TALABAT.API.Dtos;
using TALABAT.CORE.Entities;

namespace TALABAT.API.Helpers
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<Product, ProductReturnToDtos>()
                .ForMember(d => d.Brand, O => O.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.Category, O => O.MapFrom(s => s.Category.Name))
                .ForMember(d => d.PictureUrl , O => O.MapFrom<ProductPictureUrlIResolver>());

            CreateMap<CutomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
        }

    }
}
