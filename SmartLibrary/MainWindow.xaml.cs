using SmartLibrary.ViewModel;
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

namespace SmartLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var home = new HomeView();
            ContentContainer.Content = home;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var category = new CategoryView();

            ContentContainer.Content = category;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var books = new BooksView();
            ContentContainer.Content = books;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var customers = new CustomersView();
            ContentContainer.Content = customers;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var home = new HomeView();
            ContentContainer.Content = home;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var rental = new RentalsView();
            ContentContainer.Content = rental;
        }
    }
}
