using CoffeeShop.Data;
using CoffeeShop.Interfaces;
using CoffeeShop.Mutation;
using CoffeeShop.Query;
using CoffeeShop.Schema;
using CoffeeShop.Services;
using CoffeeShop.Type;
using GraphiQl;
using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IMenu, MenuService>();
            services.AddTransient<ISubmenu, SubmenuService>();
            services.AddTransient<IReservation, ReservationService>();
            //services.AddTransient<MenuType>();
            //services.AddTransient<SubmenuType>();
            //services.AddTransient<ReservationType>();
            services.AddTransient<MenuQuery>();
            services.AddTransient<SubmenuQuery>();
            services.AddTransient<ReservationQuery>();
            services.AddTransient<MenuMutation>();
            services.AddTransient<SubmenuMutation>();
            services.AddTransient<ReservationMutation>();
            services.AddTransient<RootQuery>();
            services.AddTransient<RootMutation>();

            services.AddTransient<ISchema, RootSchema>();

            GraphQL.MicrosoftDI.GraphQLBuilderExtensions
                .AddGraphQL(services)
                .AddServer(true)
                .ConfigureExecution(options => { options.EnableMetrics = false; })
                .AddGraphTypes()
                .AddSystemTextJson();
            services.AddDbContext<GraphQLDbContext>(option => option.UseSqlServer(@"Data Source= (localdb)\MSSQLLocalDB;Initial Catalog=CoffeeShopDb;Integrated Security = True"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GraphQLDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            dbContext.Database.EnsureCreated();
            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();
        }
    }
}
