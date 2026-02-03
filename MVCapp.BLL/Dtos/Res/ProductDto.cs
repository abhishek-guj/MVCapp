using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCapp.BLL.Dtos.Res
{
    public class ProductDto
    {

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public string Category { get; set; }
    }
}