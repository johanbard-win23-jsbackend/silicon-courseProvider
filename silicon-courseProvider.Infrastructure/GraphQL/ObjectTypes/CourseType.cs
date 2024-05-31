
using silicon_courseProvider.Infrastructure.Data.Entities;

namespace silicon_courseProvider.Infrastructure.GraphQL.ObjectTypes;

public class CourseType : ObjectType<CourseEntity>
{
    protected override void Configure(IObjectTypeDescriptor<CourseEntity> descriptor)
    {
        descriptor.Field(c => c.Id).Type<NonNullType<IdType>>();
        descriptor.Field(c => c.Category).Type<StringType>();
        descriptor.Field(c => c.isBestseller).Type<BooleanType>();
        descriptor.Field(c => c.SmallImageUri).Type<StringType>();
        descriptor.Field(c => c.Title).Type<StringType>();
        descriptor.Field(c => c.Description).Type<StringType>();
        descriptor.Field(c => c.Hours).Type<StringType>();
        descriptor.Field(c => c.Likes).Type<StringType>();
        descriptor.Field(c => c.LikesInPercent).Type<StringType>();
        descriptor.Field(c => c.Authors).Type<ListType<AuthorType>>();
        descriptor.Field(c => c.Prices).Type<PricesType>();
    }
}
