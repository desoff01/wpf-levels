using System;
using System.Collections.Generic;

namespace _11_level.dbModels;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
