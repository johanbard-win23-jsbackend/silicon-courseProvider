using silicon_courseProvider.Infrastructure.Data.Entities;
using silicon_courseProvider.Infrastructure.Models;

namespace silicon_courseProvider.Infrastructure.Factories;

public static class CourseFactory
{
    public static CourseEntity CreateCourseEntity(CourseCreateRequest request)
    {
        return new CourseEntity
        {
            Category = request.Category,
            Description = request.Description,
            isBestseller = request.isBestseller,
            SmallImageUri = request.SmallImageUri,
            Title = request.Title,
            Authors = request.Authors?.Select(a => new AuthorEntity
            {
                Name = a.Name,
            }).ToList(),
            Prices = request.Prices == null ? null : new PricesEntity
            {
                CurrencySymbol = request.Prices.CurrencySymbol!,
                Price = request.Prices.Price,
                DiscountPrice = request.Prices.DiscountPrice
            },
            Hours = request.Hours,
            Likes = request.Likes,
            LikesInPercent = request.LikesInPercent,
        };
    }

    public static CourseEntity CreateCourseEntity(CourseUpdateRequest request)
    {
        return new CourseEntity
        {
            Id = request.Id,
            Category = request.Category,
            isBestseller = request.isBestseller,
            SmallImageUri = request.SmallImageUri,
            Title = request.Title,
            Description = request.Description,
            Authors = request.Authors?.Select(a => new AuthorEntity
            {
                Name = a.Name,
            }).ToList(),
            Prices = request.Prices == null ? null : new PricesEntity
            {
                CurrencySymbol = request.Prices.CurrencySymbol!,
                Price = request.Prices.Price,
                DiscountPrice = request.Prices.DiscountPrice
            },
            Hours = request.Hours,
            Likes = request.Likes,
            LikesInPercent = request.LikesInPercent
        };
    }

    public static Course CreateCourse(CourseEntity entity)
    {
        return new Course
        {
            Id = entity.Id,
            Category = entity.Category,
            isBestseller = entity.isBestseller,
            SmallImageUri = entity.SmallImageUri,
            Title = entity.Title,
            Description = entity.Description,
            Authors = entity.Authors?.Select(a => new Author
            {
                Name = a.Name,
            }).ToList(),
            Prices = entity.Prices == null ? null : new Prices
            {
                CurrencySymbol = entity.Prices.CurrencySymbol!,
                Price = entity.Prices.Price,
                DiscountPrice = entity.Prices.DiscountPrice
            },
            Hours = entity.Hours,
            Likes = entity.Likes,
            LikesInPercent = entity.LikesInPercent
        };
    }
}
