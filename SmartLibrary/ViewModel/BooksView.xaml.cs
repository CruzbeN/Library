using Microsoft.EntityFrameworkCore;
using SmartLibrary.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class BooksView : UserControl
    {
        public List<Book> Books { get; set; }
        public BooksView()
        {
            InitializeComponent();

            using (LibraryDbContext _context = new LibraryDbContext())
            {
                var categories = _context.Categories.Select(p => p.Name).Distinct().ToList();
                category.ItemsSource = categories;

                Books = _context.Books
                    .Join(_context.Categories, b => b.CategoryId, c => c.CategoryId, (b, c) => new Book
                    {
                        BookId = b.BookId,
                        Title = b.Title,
                        Author = b.Author,
                        ReleaseYear = b.ReleaseYear,
                        Name = c.Name,
                    })
                    .Select(b => new Book
                    {
                        BookId = b.BookId,
                        Title = b.Title,
                        Author = b.Author,
                        ReleaseYear = b.ReleaseYear,
                        Name = b.Name,
                    })
                    .ToList();
            }
            BooksList.AutoGenerateColumns = false;
            BooksList.ItemsSource = Books;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string titlee = titletxt.Text;
            string authore = authortxt.Text;
            int year = Convert.ToInt32(releasedatetxt.Text);
            string selectedcategory = category.SelectedItem as string;


            using (LibraryDbContext _context = new LibraryDbContext())
            {
                Category? categoryy = _context.Categories.FirstOrDefault(m => m.Name == selectedcategory);
                if (categoryy != null)
                {
                    Book newbook = new Book
                    {
                        Title = titlee,
                        Author = authore,
                        ReleaseYear = year,
                        CategoryId = categoryy.CategoryId 
                    };

                    _context.Books.Add(newbook);
                    _context.SaveChanges();

                    Books = _context.Books
                    .Join(_context.Categories, b => b.CategoryId, c => c.CategoryId, (b, c) => new Book
                    {
                        BookId = b.BookId,
                        Title = b.Title,
                        Author = b.Author,
                        ReleaseYear = b.ReleaseYear,
                        Name = c.Name,
                    })
                    .Select(b => new Book
                    {
                        BookId = b.BookId,
                        Title = b.Title,
                        Author = b.Author,
                        ReleaseYear = b.ReleaseYear,
                        Name = b.Name,
                    })
                    .ToList();
                }
            }
            BooksList.AutoGenerateColumns = false;
            BooksList.ItemsSource = Books;
        }
    }
}
