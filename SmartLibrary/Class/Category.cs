using System;
using System.Collections.Generic;

namespace SmartLibrary.Class;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public Category()
    {
        Books = new List<Book>();
    }
}

/*
 * using(LibraryDbContext _context = new LibraryDbContext())
            {
                Categories = _context.Categories
                    .Select(m => new Class.Category
                    {
                        CategoryId = m.CategoryId,
                        Name= m.Name
                    })
                    .ToList();
            }
*/
