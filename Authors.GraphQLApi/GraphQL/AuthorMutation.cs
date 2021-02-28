using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authors.GraphQLApi.GraphQL.Types;
using Authors.GraphQLApi.Models;
using Authors.GraphQLApi.Service;
using GraphQL.Types;

namespace Authors.GraphQLApi.GraphQL
{
    public class AuthorMutation:ObjectGraphType
    {
        public AuthorMutation(AuthorService service)
        {
            FieldAsync<AuthorType>("createAuthor",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AuthorInputType>>()
                    {Name = "createAuthor"}),
                resolve: async context =>
                {
                    var author = context.GetArgument<Author>("createAuthor");

                    return await context.TryAsyncResolve(async c => await service.AddAuthor(author));
                });
        }
    }
}
