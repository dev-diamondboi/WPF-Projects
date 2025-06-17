using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OMSModels.Models
{
    public class Shopper
    {
        [Key]
        public int IdShopper { get; set; }
        public string Email { get; set; }

        public ICollection<Basket> Baskets { get; set; }
    }
}
