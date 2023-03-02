using System;
using System.Collections.Generic;

namespace Rs_Api.Models;

public partial class Checkout
{
    public int CheckoutId { get; set; }

    public int? CustomerId { get; set; }

    public string? Type { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? ModifyTime { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Basket> Baskets { get; } = new List<Basket>();

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
