using System.ComponentModel.DataAnnotations;

namespace TALABAT.API.Dtos
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public String ProducutName { get; set; }
        [Required]
        public String PictureUrl { get; set; }
        [Required]
        [Range(0.1, Double.MaxValue, ErrorMessage = "Price must be Greater than Zero")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be Greater than Zero")]
        public int Quantity { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Category { get; set; }


    }
}