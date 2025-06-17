using Microsoft.EntityFrameworkCore;
using OMSModels.Data;
using OMSModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMSModels.Repositories
{
    public class BasketRepository
    {
        private readonly OMSContext _context;

        public BasketRepository(OMSContext context)
        {
            _context = context;
        }

        // Get all baskets with shopper info
        public async Task<List<Basket>> GetBasketsWithShopperAsync()
        {
            return await _context.Baskets
                .Include(b => b.Shopper)
                .ToListAsync();
        }

        // Get all items for a basket (with product info)
        public async Task<List<BasketItem>> GetBasketItemsAsync(int basketId)
        {
            try
            {
                var items = await _context.BasketItems
                    .Where(bi => bi.IdBasket == basketId)
                    .Include(bi => bi.Product)
                    .ToListAsync();

                // DEBUG TYPE DUMP — SHOW TYPES
                foreach (var item in items)
                {
                    System.Diagnostics.Debug.WriteLine($"Product ID: {item.Product?.IdProduct} | Type: {item.Product?.IdProduct.GetType()}");
                }

                return items;
            }
            catch (Exception ex)
            {
                // Log the root cause
                System.Diagnostics.Debug.WriteLine($"🔥 ERROR: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"🔥 INNER: {ex.InnerException?.Message}");
                System.Diagnostics.Debug.WriteLine($"🔥 STACK: {ex.StackTrace}");

                throw; // Re-throw to keep behavior same
            }
        }


        // Get all products
        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return products;
            }
            catch (Exception ex)
            {
                var debugInfo = $@"
🔥 EXCEPTION CAUGHT in GetProductsAsync()
File   : BasketRepository.cs
Class  : BasketRepository
Method : GetProductsAsync()
Time   : {DateTime.Now}

➡️ MESSAGE  : {ex.Message}
➡️ SOURCE   : {ex.Source}
➡️ TYPE     : {ex.GetType().Name}
➡️ STACK    : {ex.StackTrace}
➡️ INNER    : {ex.InnerException?.Message ?? "None"}
";

                System.Diagnostics.Debug.WriteLine(debugInfo);
                Console.WriteLine(debugInfo);

                throw; // re-throw for visibility
            }
        }


        // Add a new basket item
        public async Task AddBasketItemAsync(BasketItem newItem)
        {
            await _context.BasketItems.AddAsync(newItem);
            await _context.SaveChangesAsync();
        }

        // Get next BasketItem ID (max + 1)
        public async Task<int> GetNextBasketItemIdAsync()
        {
            var maxId = await _context.BasketItems.MaxAsync(bi => (int?)EF.Property<short>(bi, "IdBasketItem")) ?? 0;
            return maxId + 1;
        }

    }
}
