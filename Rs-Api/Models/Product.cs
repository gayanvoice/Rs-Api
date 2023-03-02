using System;
using System.Collections.Generic;

namespace Rs_Api.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Size { get; set; }

    public double Price { get; set; }

    public int Kcal { get; set; }

    public int NoOfServe { get; set; }

    public string Status { get; set; } = null!;

    public int? GuideId { get; set; }

    public int? AlergyId { get; set; }

    public virtual Allergy? Alergy { get; set; }

    public virtual ICollection<Basket> Baskets { get; } = new List<Basket>();

    public virtual Guide? Guide { get; set; }

    public virtual ICollection<ProductContent> ProductContents { get; } = new List<ProductContent>();
}
