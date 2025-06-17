using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMSModels.Models
{
    public class BasketItem
    {
        [Key]
        public int IdBasketItem { get; set; }     

        [ForeignKey("Basket")]
        public int IdBasket { get; set; }         

        [ForeignKey("Product")]
        public int IdProduct { get; set; }      

        public byte Quantity { get; set; }        

        public Basket Basket { get; set; }
        public Product Product { get; set; }
    }
}
