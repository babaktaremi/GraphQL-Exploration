using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authors.GraphQLApi.GraphQL;
using Authors.GraphQLApi.Models;
using Authors.GraphQLApi.Service;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

namespace Authors.GraphQLApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=SampleGraphQL;Integrated Security=true")
                    .LogTo(Console.WriteLine);
            });
            #endregion


            #region IOC

            services.AddScoped<AuthorService>();

            #endregion

            #region GraphQL
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<AuthorQuery>();
            services.AddScoped<AuthorScheme>();

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddWebSockets();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGraphQL<AuthorScheme>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
        
    }
}
