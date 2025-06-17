using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OMSModels.Models
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; } 

        public string ProductName { get; set; }

        public string Info => ProductName;

        public decimal Price { get; set; }

        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
