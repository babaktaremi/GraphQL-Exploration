using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authors.GraphQLApi.Models;
using Authors.GraphQLApi.Service;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace Authors.GraphQLApi.GraphQL.Types
{
    public sealed class AuthorType:ObjectGraphType<Author>
    {
        public AuthorType(AuthorService service,IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Field(c => c.Id);
            Field(c => c.AuthorIdentifier);
            Field(c => c.FirstName);
            Field(c => c.LastName);
            Field<AuthorTypeLevel>("authorType", "Type Of Author");

            Field<ListGraphType<BookType>>("books",resolve: context =>
            {
                var loader =
                    dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, Book>(
                        "GetReviewsByProductId", service.GetAuthorBooksAsync);
                return loader.LoadAsync(context.Source.Id);
            });

            Field<ListGraphType<BookType>>("authorBooks", arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id"
                }), resolve: context =>
            {
                var id = context.GetArgument<int>("id");
                return service.GetAuthorBooksAsync(id);
            });
        }
    }
}
