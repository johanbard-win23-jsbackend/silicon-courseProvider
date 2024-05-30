using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace silicon_courseProvider.Infrastructure.Data.Entities;

public class CourseEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Category { get; set; } = null!;
    public bool isBestseller { get; set; }
    public string? SmallImageUri { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Hours { get; set; }
    public string? Likes { get; set; }
    public string? LikesInPercent { get; set; }
    public virtual List<AuthorEntity>? Authors { get; set; }
    public PricesEntity? Prices { get; set; }
}

public class PricesEntity
{
    public string CurrencySymbol { get; set; } = "$";
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
}

public class AuthorEntity
{
    public string? Name { get; set; }
}