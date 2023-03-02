using System;
using System.Collections.Generic;

namespace Rs_Api.Models;

public partial class Guide
{
    public int GuideId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
