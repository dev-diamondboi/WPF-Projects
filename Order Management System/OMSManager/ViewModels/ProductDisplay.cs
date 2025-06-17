using OMSModels.Models;

namespace OMSManager.ViewModels
{
    public class ProductDisplay
    {
        public Product Product { get; set; }

        public string DisplayText => $"{Product.ProductName}";
    }
}
