using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace Authors.GraphQLApi.GraphQL.Types
{
    public class AuthorInputType:InputObjectGraphType
    {
        public AuthorInputType()
        {
            Name = "authorInput";
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<StringGraphType>>("authorIdentifier");
            Field<NonNullGraphType<DateGraphType>>("dateOfBirth");
        }
    }
}
