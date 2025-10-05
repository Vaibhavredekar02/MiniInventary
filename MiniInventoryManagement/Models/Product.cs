using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MiniInventoryManagement.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage ="Product Name is required")]
        public string ProductName { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }


        public DateTime CreatedDate { get; set; }

        public  List<Product> lstProducts { get; set; }
    }
}