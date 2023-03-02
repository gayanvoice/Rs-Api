using System;
using System.Collections.Generic;

namespace Rs_Api.Models;

public partial class Clock
{
    public int ClockId { get; set; }

    public int StaffId { get; set; }

    public DateTime? ClockInTime { get; set; }

    public DateTime? ClockOutTime { get; set; }

    public string? Status { get; set; }

    public virtual Staff Staff { get; set; } = null!;
}
