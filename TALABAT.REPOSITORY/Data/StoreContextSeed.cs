using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TALABAT.CORE.Entities;

namespace TALABAT.REPOSITORY.Data
{
    public static class StoreContextSeed
    {
        public async static Task SeedAsync(StoreContext _dbcontext)
        {
            if (_dbcontext.ProductBrands.Count() == 0) // or  !_dbcontext.ProductBrands.Any()
            {
                var BrandData = File.ReadAllText("../TALABAT.REPOSITORY/Data/Data Seeding/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandData);
                if (brands?.Count() > 0)
                {
                    foreach (var brand in brands)
                    {
                        _dbcontext.Set<ProductBrand>().Add(brand);
                    }
                    await _dbcontext.SaveChangesAsync();

                } 
            }

            if (_dbcontext.ProductCategories.Count() == 0) // or  !_dbcontext.ProductBrands.Any()
            {
                var CategoriesData = File.ReadAllText("../TALABAT.REPOSITORY/Data/Data Seeding/categories.json");
                var Categories = JsonSerializer.Deserialize<List<ProductCategory>>(CategoriesData);
                if (Categories?.Count() > 0)
                {
                    foreach (var category in Categories)
                    {
                        _dbcontext.Set<ProductCategory>().Add(category);
                    }
                    await _dbcontext.SaveChangesAsync();

                }
            }


            if (_dbcontext.Products.Count() == 0) // or  !_dbcontext.ProductBrands.Any()
            {
                var ProductsData = File.ReadAllText("../TALABAT.REPOSITORY/Data/Data Seeding/products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                if (Products?.Count() > 0)
                {
                    foreach (var Product in Products)
                    {
                        _dbcontext.Set<Product>().Add(Product);
                    }
                    await _dbcontext.SaveChangesAsync();

                }
            }
        }

    }
}
