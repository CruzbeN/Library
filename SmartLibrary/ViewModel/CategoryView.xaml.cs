using SmartLibrary;
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
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : UserControl
    {
        public List<Category>? Categories { get; set; }
        public CategoryView()
        {
            InitializeComponent();

            try
            {
                using (LibraryDbContext _context = new LibraryDbContext())
                {
                    Categories = _context.Categories
                        .Select(m => new Class.Category
                        {
                            CategoryId = m.CategoryId,
                            Name = m.Name
                        })
                        .ToList();
                }

                CategoryList.AutoGenerateColumns = false;
                CategoryList.ItemsSource = Categories;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
            

        }
    }
}
