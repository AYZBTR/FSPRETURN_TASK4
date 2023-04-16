using System;
using System.Collections.Generic;

namespace FSPRETURN_TASK4.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<PlacedOrder> PlacedOrders { get; set; } = new List<PlacedOrder>();
}
