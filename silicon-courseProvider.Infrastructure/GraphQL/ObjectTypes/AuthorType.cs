using silicon_courseProvider.Infrastructure.Data.Entities;

namespace silicon_courseProvider.Infrastructure.GraphQL.ObjectTypes;

public class AuthorType : ObjectType<AuthorEntity>
{
    protected override void Configure(IObjectTypeDescriptor<AuthorEntity> descriptor)
    {
        descriptor.Field(a => a.Name).Type<StringType>();
    }
}