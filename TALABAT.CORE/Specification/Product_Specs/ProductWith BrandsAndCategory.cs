using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TALABAT.CORE.Entities;
using TALABAT.CORE.Specification;

namespace TALABAT.CORE.Specification.Product_Specs
{
    public class ProductWith_BrandsAndCategory : BaseSpecefecation<Product>
    {
       
        public ProductWith_BrandsAndCategory(ProductPrams Prams) 
            : base( p=>
                    
                         ( !Prams.BrandId.HasValue || p.BrandId == Prams.BrandId.Value)&&
                         (!Prams.CategoryId.HasValue || p.CategoryId == Prams.CategoryId.Value)
          
                  )

        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);

            if (!string.IsNullOrEmpty(Prams.Sort))
            {
                switch (Prams.Sort)
                {
                    case "PriceAsc":
                        //OrderBy= p=>p.Price;
                        AddOrderby(p => p.Price);
                        break;
                    case "PriceDes":
                        //OrderBydes = p=>p.Price;
                        AddOrderbyDes(p => p.Price);
                        break;
                    default:
                        //OrderBy = p=>p.Name;
                        AddOrderby(p => p.Name);
                        break;
                }
            }
            else
                AddOrderby(p => p.Name);

            
        }

       
        public ProductWith_BrandsAndCategory(int id) : base(p =>p .Id == id)
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }
}
