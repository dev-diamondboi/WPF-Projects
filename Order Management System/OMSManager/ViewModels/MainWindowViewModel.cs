using OMSModels.Data;
using OMSModels.Models;
using OMSModels.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OMSManager.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly BasketRepository _repository;

        public ObservableCollection<Basket> Baskets { get; set; } = new();
        public ObservableCollection<BasketItem> BasketItems { get; set; } = new();

        private Basket _selectedBasket;
        public Basket SelectedBasket
        {
            get => _selectedBasket;
            set
            {
                _selectedBasket = value;
                OnPropertyChanged();
                if (_selectedBasket != null)
                    LoadBasketItemsAsync(_selectedBasket.IdBasket);
            }
        }

        public MainWindowViewModel()
        {
            var options = OMSContextFactory.CreateDbOptions();
            var context = new OMSContext(options);
            _repository = new BasketRepository(context);

            _ = LoadBasketsAsync();
        }

        private async Task LoadBasketsAsync()
        {
            try
            {
                var baskets = await _repository.GetBasketsWithShopperAsync();

                System.Windows.MessageBox.Show($"Loaded {baskets.Count} baskets from DB");

                Baskets.Clear();

                foreach (var basket in baskets)
                {
                    Baskets.Add(basket);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"ERROR: {ex.Message}");
            }
        }





        private async Task LoadBasketItemsAsync(int basketId)
        {
            var items = await _repository.GetBasketItemsAsync(basketId);
            BasketItems.Clear();
            foreach (var item in items)
                BasketItems.Add(item);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
