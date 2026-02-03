using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MVCapp.DAL.Enums;

namespace MVCapp.BLL.Dtos.Req
{
    public class ProductUpdateDto
    {
        [Required(ErrorMessage = "Id is required....!")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required....!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required....!")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Qty is required....!")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Category is required....!")]
        public string Category { get; set; }
    }
}