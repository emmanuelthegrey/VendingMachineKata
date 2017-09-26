using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VendingMachineKata.ViewModels;

namespace VendingMachineKata
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VendingMachineViewModel _rickAndMortysVendingMachine = new VendingMachineViewModel();
        public MainWindow()
        {

            
            InitializeComponent();
            DataContext = _rickAndMortysVendingMachine;

        }

        private void OnClick_Refill(object sender, RoutedEventArgs e)
        {
            _rickAndMortysVendingMachine.Refill();
        }

        private void OnClick_InsertDime(object sender, RoutedEventArgs e)
        {
            _rickAndMortysVendingMachine.InsertDime();
        }

        private void OnClick_InsertNickle(object sender, RoutedEventArgs e)
        {
            _rickAndMortysVendingMachine.InsertNickel();
        }

        private void OnClick_InsertQuater(object sender, RoutedEventArgs e)
        {
            _rickAndMortysVendingMachine.InsertQuater();
        }

        private void OnClick_ReturnChange(object sender, RoutedEventArgs e)
        {
            _rickAndMortysVendingMachine.ReturnChange();
        }

        private void OnClick_InsertBadCoin(object sender, RoutedEventArgs e)
        {
            _rickAndMortysVendingMachine.InsertBadCoin();

            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ((ListView)sender).SelectedItem as ItemViewModel;

             if (selectedItem.Item.Price == 0.65M && _rickAndMortysVendingMachine.MoneyInMachine.DimeCount < 1)
            {
                _rickAndMortysVendingMachine.ExactChangeMessage = "Exact Change Needed";
            }
            else
            {
                _rickAndMortysVendingMachine.ExactChangeMessage = "";
            }
        }
    }
}
