using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartLibrary.Class;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public int? ReleaseYear { get; set; }

    public int? CategoryId { get; set; }

    [NotMapped]
    public string? Name { get; set; } 

    public virtual Category? Category { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
