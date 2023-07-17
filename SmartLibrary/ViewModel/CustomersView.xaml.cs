using Microsoft.EntityFrameworkCore;
using SmartLibrary.Class;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartLibrary.ViewModel
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        public List<Customer> Customers { get; set; }
        public CustomersView()
        {
            InitializeComponent();

            try
            {
                using (LibraryDbContext _context = new LibraryDbContext())
                {
                    Customers = _context.Customers
                        .Select(m => new Customer
                        {
                            CustomerId= m.CustomerId,
                            FirstName= m.FirstName,
                            LastName= m.LastName,
                            Address= m.Address
                        })
                        .ToList();
                }

                CustomersList.AutoGenerateColumns = false;
                CustomersList.ItemsSource = Customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(sname.Text) || string.IsNullOrEmpty(adress.Text))
                {
                    MessageBox.Show("Fill all of the fields required to add record!");
                }
                else
                {
                    Customer cst = new Customer
                    {
                        FirstName = char.ToUpper(name.Text[0]) + name.Text.Substring(1),
                        LastName = char.ToUpper(sname.Text[0]) + sname.Text.Substring(1),
                        Address = adress.Text
                    };

                    using (LibraryDbContext context = new LibraryDbContext())
                    {
                        context.Customers.Add(cst);
                        context.SaveChanges();

                        Customers = context.Customers
                       .Select(m => new Customer
                       {
                           CustomerId = m.CustomerId,
                           FirstName = m.FirstName,
                           LastName = m.LastName,
                           Address = m.Address
                       })
                       .ToList();
                    }
                    CustomersList.AutoGenerateColumns = false;
                    CustomersList.ItemsSource = Customers;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Wrong format");
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }
    }
}
