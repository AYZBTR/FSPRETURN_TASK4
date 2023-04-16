using System;
using System.Collections.Generic;

namespace FSPRETURN_TASK4.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
