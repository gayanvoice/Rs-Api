using System;
using System.Collections.Generic;

namespace Rs_Api.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public DateTime? ModifyTime { get; set; }

    public virtual ICollection<Checkout> Checkouts { get; } = new List<Checkout>();
}
