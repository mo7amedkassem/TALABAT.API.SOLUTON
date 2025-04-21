using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;
using TALABAT.API.Dtos;
using TALABAT.API.Helpers;
using TALABAT.CORE;
using TALABAT.CORE.Entities;
using TALABAT.CORE.Repository.Contract;
using TALABAT.CORE.Specification;
using TALABAT.CORE.Specification.Product_Specs;

namespace TALABAT.API.Controllers
{
  
    public class ProductsController : BaseController
    {
        private readonly IGenaricRepository<Product> _productsRepo;
        private readonly IGenaricRepository<ProductBrand> _brandrepo;
        private readonly IGenaricRepository<ProductCategory> _categoryRepo;
        private readonly IMapper _mapper;

        public ProductsController(
            IGenaricRepository<Product> ProductsRepo ,
            IGenaricRepository<ProductBrand> brandrepo,
            IGenaricRepository<ProductCategory> categoryRepo,
            IMapper mapper )
        {
            _productsRepo = ProductsRepo;
            _brandrepo = brandrepo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<Pagination<ProductReturnToDtos>>> GetProducts([FromQuery]ProductPrams Prams)
        {

          
            var spec = new ProductWith_BrandsAndCategory(Prams);
            var product = await _productsRepo.GetAllBySpecAsync(spec);
            var mappedproducts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductReturnToDtos>>(product);

            //var returnedObjects = new Pagination<ProductReturnToDtos>()
            //{
            //    PageIndex = Prams.PageIndex ,
            //};




            return Ok(mappedproducts);
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReturnToDtos>> GetProduct(int id)
        {

            var spec = new ProductWith_BrandsAndCategory(id);

            var product = await _productsRepo.GetBySpecAsync(spec);

            if (product is null)
                return NotFound(new { Message = "Not Found", StatusCode = 404 });

            return Ok(_mapper.Map<Product, ProductReturnToDtos>(product));


        }





        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> getallcategory ()
        {

            var categgories = await _categoryRepo.GetAllAsync();
            return Ok(categgories);

        }

        [HttpGet("Brand")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> getallBrands()
        {

            var Brands = await _brandrepo.GetAllAsync();
            return Ok(Brands);

        }

    }
}
