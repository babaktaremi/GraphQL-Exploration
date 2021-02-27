using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authors.GraphQLApi.Models;
using GraphQL.Types;

namespace Authors.GraphQLApi.GraphQL.Types
{
    public sealed class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(c => c.AuthorId);
            Field(c => c.Name);
            Field(c => c.Id);
        }
    }
}
