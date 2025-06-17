using OMSManager.Views;
using OMSManager.ViewModels;
using OMSModels.Models;
using System.Windows;

namespace OMSManager
{
    public partial class MainWindow : Window
    {
        private Basket _lastSelectedBasket;

        public MainWindow()
        {
            InitializeComponent();
            MainContentControl.Content = new ListOrderDetailsView(); 
        }

        private void ListOrderDetails_Click(object sender, RoutedEventArgs e)
        {
            if (_lastSelectedBasket != null)
            {
                MainContentControl.Content = new ListOrderDetailsView(_lastSelectedBasket);
            }
            else
            {
                MessageBox.Show("Please select a basket first by adding an item.");
            }
        }

        private void AddItemToOrder_Click(object sender, RoutedEventArgs e)
        {
            var addView = new AddNewItemView();

            // Tap into ViewModel to monitor basket selection
            if (addView.DataContext is AddNewItemViewModel vm)
            {
                vm.PropertyChanged += (s, args) =>
                {
                    if (args.PropertyName == nameof(vm.SelectedBasket))
                    {
                        _lastSelectedBasket = vm.SelectedBasket;
                    }
                };
            }

            MainContentControl.Content = addView;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
