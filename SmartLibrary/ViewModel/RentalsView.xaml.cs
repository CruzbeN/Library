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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartLibrary.ViewModel
{
    /// <summary>
    /// Interaction logic for Rentals.xaml
    /// </summary>
    public partial class RentalsView : UserControl
    {
        public List<Rental> Rentals { get; set; }
        public RentalsView()
        {
            InitializeComponent();

            using (LibraryDbContext _context = new LibraryDbContext())
            {
                Rentals = _context.Rentals
                    .Join(_context.Customers, r => r.CustomerId, c => c.CustomerId, (r, c) => new {Rental = r, Customer = c })
                    .Join(_context.Books, rr => rr.Rental.BookId, b => b.BookId, (rr, b) => new Rental{
                    RentalId = rr.Rental.RentalId,
                    FirstName = rr.Customer.FirstName,
                    LastName = rr.Customer.LastName,
                    Title = b.Title,
                    BorrowDate = rr.Rental.BorrowDate,
                    ReturnDate= rr.Rental.ReturnDate
                    })
                    .Select(r => new Rental
                    {
                        RentalId = r.RentalId,
                        FirstName = r.FirstName,
                        LastName = r.LastName,
                        Title = r.Title,
                        BorrowDate = r.BorrowDate,
                        ReturnDate = r.ReturnDate
                    })
                    .ToList();
            }
            RentalsList.AutoGenerateColumns = false;
            RentalsList.ItemsSource = Rentals;
        }
    }
    
}
