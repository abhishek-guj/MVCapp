using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCapp.DAL.Enums;

namespace MVCapp.DAL.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public ProductCategory Category { get; set; }

    }
}