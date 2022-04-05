using CoffeeShop.Interfaces;
using CoffeeShop.Type;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Query
{
    public class SubmenuQuery : ObjectGraphType
    {
        public SubmenuQuery(ISubmenu submenuService)
        {
            Field<ListGraphType<SubmenuType>>("submenus", resolve: context => { return submenuService.GetSubmenus(); });

            Field<ListGraphType<SubmenuType>>("submenusById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => { return submenuService.GetSubmenus(context.GetArgument<int>("id")); });
        }
    }
}
