using OMSModels.Data;
using OMSModels.Models;
using OMSModels.Repositories;
using System.Collections.ObjectModel;

namespace OMSManager.ViewModels
{
    public class ListOrderDetailsViewModel
    {
        public ObservableCollection<Basket> Baskets { get; set; } = new();
        public ObservableCollection<BasketItem> BasketItems { get; set; } = new();
        public Basket SelectedBasket { get; set; }

        public async void LoadBasketItems(Basket basket)
        {
            var context = new OMSContext(OMSContextFactory.CreateDbOptions());
            var repo = new BasketRepository(context);

            Baskets.Clear();
            var allBaskets = await repo.GetBasketsWithShopperAsync();
            foreach (var b in allBaskets)
                Baskets.Add(b);

            SelectedBasket = basket;

            BasketItems.Clear();
            var items = await repo.GetBasketItemsAsync(basket.IdBasket);
            foreach (var item in items)
                BasketItems.Add(item);
        }
    }
}
