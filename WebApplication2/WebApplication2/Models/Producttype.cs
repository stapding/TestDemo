using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Producttype
{
    public int ProductTypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
