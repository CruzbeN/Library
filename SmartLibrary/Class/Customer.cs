using System;
using System.Collections.Generic;

namespace SmartLibrary.Class;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
