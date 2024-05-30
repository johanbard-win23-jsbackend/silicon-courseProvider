namespace silicon_courseProvider.Infrastructure.Models;

public class Course
{
    public string Id { get; set; } = null!;
    public string Category { get; set; } = null!;
    public bool isBestseller { get; set; }
    public string? SmallImageUri { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Hours { get; set; }
    public string? Likes { get; set; }
    public string? LikesInPercent { get; set; }
    public virtual List<Author>? Authors { get; set; }
    public virtual Prices? Prices { get; set; }
}

public class Prices
{
    public string? CurrencySymbol { get; set; }
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
}

public class Author
{
    public string? Name { get; set; }
}
