using System;
using System.Collections.Generic;

namespace Rs_Api.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public int CheckoutId { get; set; }

    public int StaffId { get; set; }

    public string Task1 { get; set; } = null!;

    public string? Comment { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Status { get; set; } = null!;

    public virtual Checkout Checkout { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
