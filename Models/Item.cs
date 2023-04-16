using System;
using System.Collections.Generic;

namespace FSPRETURN_TASK4.Models;

public partial class Item
{
    public int Id { get; set; }

    public int PlacedOrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual PlacedOrder PlacedOrder { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
