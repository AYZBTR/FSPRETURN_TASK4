using System;
using System.Collections.Generic;

namespace FSPRETURN_TASK4.Models;

public partial class PlacedOrder
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
