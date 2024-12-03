using System;
using System.Collections.Generic;

namespace harmic.Models;

public partial class TbProduct
{
    public int ProductId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public int? CategoryProductId { get; set; }

    public string? Description { get; set; }

    public string? Detail { get; set; }

    public string? Image { get; set; }

    public int? Price { get; set; }

    public bool? IsSale { get; set; }

    public int? Quantity { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsNew { get; set; }

    public bool IsBestSeller { get; set; }

    public bool IsActive { get; set; }

    public bool? InStock { get; set; }

    public int? Star { get; set; }

    public int PriceSale { get; set; }

    public virtual TbProductCategory? CategoryProduct { get; set; }

    public virtual ICollection<TbProductReview> TbProductReviews { get; set; } = new List<TbProductReview>();
}
