using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authors.GraphQLApi.Models;
using Authors.GraphQLApi.Service;
using GraphQL.Types;

namespace Authors.GraphQLApi.GraphQL.Types
{
    public sealed class AuthorType:ObjectGraphType<Author>
    {
        public AuthorType(AuthorService service)
        {
            Field(c => c.Id);
            Field(c => c.AuthorIdentifier);
            Field(c => c.FirstName);
            Field(c => c.LastName);
            Field<AuthorTypeLevel>("authorType", "Type Of Author");
            Field<ListGraphType<BookType>>("books",resolve:context=>service.GetAuthorBooksAsync(context.Source.Id));
        }
    }
}
