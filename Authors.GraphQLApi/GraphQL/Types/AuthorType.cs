using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authors.GraphQLApi.Models;
using GraphQL.Types;

namespace Authors.GraphQLApi.GraphQL.Types
{
    public sealed class AuthorType:ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(c => c.Id);
            Field(c => c.AuthorIdentifier);
            Field(c => c.FirstName);
            Field(c => c.LastName);
        }
    }
}
