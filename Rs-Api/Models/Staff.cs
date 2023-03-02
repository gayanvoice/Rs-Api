using System;
using System.Collections.Generic;

namespace Rs_Api.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Address { get; set; } = null!;

    public string Brpno { get; set; } = null!;

    public int Nino { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreateTime { get; set; }

    public virtual ICollection<Clock> Clocks { get; } = new List<Clock>();

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
