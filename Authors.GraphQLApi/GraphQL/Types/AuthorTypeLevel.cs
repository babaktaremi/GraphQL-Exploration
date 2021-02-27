using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authors.GraphQLApi.Models;
using GraphQL.Types;

namespace Authors.GraphQLApi.GraphQL.Types
{
    public class AuthorTypeLevel:EnumerationGraphType<AuthorLevel>
    {
        public AuthorTypeLevel()
        {
            Name = "AuthorLevel";
            Description = "Determines the level of author";
        }
    }
}
