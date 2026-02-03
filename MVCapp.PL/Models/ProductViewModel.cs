using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCapp.PL.Models
{
    public class ProductViewModel
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public string Category { get; set; }

    }
}