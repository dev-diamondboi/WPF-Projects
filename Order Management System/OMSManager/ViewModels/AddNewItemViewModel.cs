using OMSModels.Data;
using OMSModels.Models;
using OMSModels.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OMSManager.ViewModels
{
    public class AddNewItemViewModel : INotifyPropertyChanged
    {
        private readonly BasketRepository _repository;

        public ObservableCollection<Basket> Baskets { get; set; } = new();
        public ObservableCollection<ProductDisplay> ProductDisplays { get; set; } = new();

        private Basket _selectedBasket;
        public Basket SelectedBasket
        {
            get => _selectedBasket;
            set
            {
                _selectedBasket = value;
                OnPropertyChanged();
                RaiseCanExecuteChanged();
            }
        }

        private ProductDisplay _selectedProductDisplay;
        public ProductDisplay SelectedProductDisplay
        {
            get => _selectedProductDisplay;
            set
            {
                _selectedProductDisplay = value;
                OnPropertyChanged();
                RaiseCanExecuteChanged();
            }
        }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged();
                RaiseCanExecuteChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public AddNewItemViewModel()
        {
            var options = OMSContextFactory.CreateDbOptions();
            var context = new OMSContext(options);
            _repository = new BasketRepository(context);

            SaveCommand = new RelayCommand(async () => await SaveAsync(), CanSave);

            InitializeAsync(); // ensures async is awaited
        }

        private async void InitializeAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var baskets = await _repository.GetBasketsWithShopperAsync();
            Baskets.Clear();
            foreach (var b in baskets)
                Baskets.Add(b);

            var products = await _repository.GetProductsAsync();
            ProductDisplays.Clear();
            foreach (var p in products)
                ProductDisplays.Add(new ProductDisplay { Product = p });

            MessageBox.Show($"Loaded {products.Count} products from DB");
        }

        private bool CanSave()
        {
            return SelectedBasket != null && SelectedProductDisplay != null && Quantity > 0;
        }

        private async Task SaveAsync()
        {
            var newItem = new BasketItem
            {
                IdBasketItem = await _repository.GetNextBasketItemIdAsync(),
                IdBasket = SelectedBasket.IdBasket,
                IdProduct = SelectedProductDisplay.Product.IdProduct,
                Quantity = (byte)Quantity

            };

            await _repository.AddBasketItemAsync(newItem);
            MessageBox.Show("Item added successfully!");

            // Clear form
            SelectedProductDisplay = null;
            Quantity = 0;
        }

        private void RaiseCanExecuteChanged()
        {
            if (SaveCommand is RelayCommand cmd)
                cmd.RaiseCanExecuteChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
