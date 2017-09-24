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
    }
}
