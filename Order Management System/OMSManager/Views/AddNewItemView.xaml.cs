using OMSManager.Views;
using System.Windows;
using System.Windows.Controls;

namespace OMSManager.Views
{
    public partial class AddNewItemView : UserControl
    {
        public AddNewItemView()
        {
            InitializeComponent();

            MessageBox.Show("AddNewItemView constructor started");

            var vm = new ViewModels.AddNewItemViewModel();
            this.DataContext = vm;

            MessageBox.Show("AddNewItemViewModel was created");
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
           
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.MainContentControl.Content = new ListOrderDetailsView();
            }
        }
    }
}
