using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMSModels.Models
{
    public class Basket
    {
        [Key]
        public int IdBasket { get; set; }

        [ForeignKey("Shopper")]
        public int IdShopper { get; set; }

        public Shopper Shopper { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
