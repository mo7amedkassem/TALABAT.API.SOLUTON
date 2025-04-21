using System.ComponentModel.DataAnnotations;
using TALABAT.CORE.Entities;

namespace TALABAT.API.Dtos
{
    public class CutomerBasketDto
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }
    }
}
