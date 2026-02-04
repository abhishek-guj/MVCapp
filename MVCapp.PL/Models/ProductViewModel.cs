using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCapp.BLL.Dtos.Res;

namespace MVCapp.PL.Models
{
    public class ProductViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public int TotalQty { get; set; }
    }
}