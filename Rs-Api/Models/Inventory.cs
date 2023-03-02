using System;
using System.Collections.Generic;

namespace Rs_Api.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int ProductContentId { get; set; }

    public int Quantity { get; set; }

    public DateTime? ManufactureDate { get; set; }

    public DateTime StockDate { get; set; }

    public DateTime ExpireDate { get; set; }

    public string? Comment { get; set; }

    public string Status { get; set; } = null!;

    public virtual ProductContent ProductContent { get; set; } = null!;
}
