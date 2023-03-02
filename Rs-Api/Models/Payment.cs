using System;
using System.Collections.Generic;

namespace Rs_Api.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int CheckoutId { get; set; }

    public int StaffId { get; set; }

    public string Type { get; set; } = null!;

    public double TransactionAmount { get; set; }

    public double RemainingAmount { get; set; }

    public double TotalAmount { get; set; }

    public DateTime CreateTime { get; set; }

    public virtual Checkout Checkout { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
