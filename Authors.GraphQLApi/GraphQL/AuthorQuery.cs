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
    public class AuthorQuery:ObjectGraphType
    {
        public AuthorQuery(AuthorService authorService)
        {
            Field<ListGraphType<AuthorType>>("authors",
                resolve: context => authorService.GetAllAsync());
        }
    }
}
