using System;
using System.Collections.Generic;

namespace Rs_Api.Models;

public partial class Basket
{
    public int BacketId { get; set; }

    public int CheckoutId { get; set; }

    public int ProductId { get; set; }

    public double Quantity { get; set; }

    public double TotalAmount { get; set; }

    public DateTime CreateTime { get; set; }

    public virtual Checkout Checkout { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
