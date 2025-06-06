﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TALABAT.CORE.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        public String ProducutName { get; set; }
        public String PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
    }
}
