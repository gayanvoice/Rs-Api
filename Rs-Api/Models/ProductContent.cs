using System;
using System.Collections.Generic;

namespace Rs_Api.Models;

public partial class ProductContent
{
    public int ProductContentId { get; set; }

    public int? ProductId { get; set; }

    public string? Name { get; set; }

    public double? Quantity { get; set; }

    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    public virtual Product? Product { get; set; }
}
