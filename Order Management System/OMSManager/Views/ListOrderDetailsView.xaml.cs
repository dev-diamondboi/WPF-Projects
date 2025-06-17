using OMSModels.Models;
using OMSManager.ViewModels;
using System.Windows.Controls;

namespace OMSManager.Views
{
    public partial class ListOrderDetailsView : UserControl
    {
        public ListOrderDetailsView()
        {
            InitializeComponent();
            DataContext = new ListOrderDetailsViewModel();
        }

        public ListOrderDetailsView(Basket selectedBasket)
        {
            InitializeComponent();
            var vm = new ListOrderDetailsViewModel();
            DataContext = vm;
            vm.LoadBasketItems(selectedBasket);
        }
    }
}
