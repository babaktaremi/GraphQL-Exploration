using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Authors.GraphQLApi.GraphQL
{
    public class AuthorScheme:Schema
    {
        public AuthorScheme(IDependencyResolver resolver):base(resolver)
        {
            Query = resolver.Resolve<AuthorQuery>();
            Mutation = resolver.Resolve<AuthorMutation>();
        }
    }
}
