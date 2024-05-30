using silicon_courseProvider.Infrastructure.Data.Entities;

namespace silicon_courseProvider.Infrastructure.GraphQL.ObjectTypes;

public class PricesType : ObjectType<PricesEntity>
{
    protected override void Configure(IObjectTypeDescriptor<PricesEntity> descriptor)
    {
        descriptor.Field(p => p.CurrencySymbol).Type<StringType>();
        descriptor.Field(p => p.Price).Type<StringType>();
        descriptor.Field(p => p.DiscountPrice).Type<StringType>();
    }
}
