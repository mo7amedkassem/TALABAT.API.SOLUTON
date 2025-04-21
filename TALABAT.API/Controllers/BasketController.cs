using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TALABAT.API.Dtos;
using TALABAT.CORE.Entities;
using TALABAT.CORE.Repository.Contract;

namespace TALABAT.API.Controllers
{

    public class BasketController : BaseController
    {
        private readonly IBasketRepo _basketRepo;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepo basketRepo, IMapper mapper)
        {
            _basketRepo = basketRepo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<CustomerBasket>> GetBasket (string id)
        {
            var basket = await _basketRepo.GetBasketAsync (id);
            return basket ?? new CustomerBasket (id);
        }


        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBasket(string id)
        //{
        //    var result = await _basketRepo.DeleteBasketasync(id);
        //    if (!result) 
        //    {
        //        return NotFound(new { message = "Basket not found" });
        //    }

        //    return NoContent(); 
        //}


        [HttpDelete]
        public async Task DeleteBasket(string  id)
        {
             await _basketRepo.DeleteBasketasync(id);
        }



        [HttpPost] // POST: /api/basket 
         public async Task<ActionResult<CustomerBasket>> UpdateBasket(CutomerBasketDto basket)
        {
            var mappedBasket = _mapper.Map<CutomerBasketDto, CustomerBasket>(basket);
            var createdOrUpdatedBasket = await _basketRepo.UpdateBasket(mappedBasket);
            if (createdOrUpdatedBasket is null) return BadRequest();
            return Ok(createdOrUpdatedBasket);
        }






















    }
}
