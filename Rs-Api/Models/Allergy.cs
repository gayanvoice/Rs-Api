using System;
using System.Collections.Generic;

namespace Rs_Api.Models;

public partial class Allergy
{
    public int AllergyId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
