using CoffeeShop.Interfaces;
using CoffeeShop.Models;
using CoffeeShop.Type;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Mutation
{
    public class SubmenuMutation : ObjectGraphType
    {
        public SubmenuMutation(ISubmenu submenuService)
        {
            Field<SubmenuType>("createSubmenu",
                arguments: new QueryArguments(new QueryArgument<SubmenuInputType> { Name = "submenu" }),
                resolve: context => { return submenuService.AddSubmenu(context.GetArgument<Submenu>("submenu")); });
        }
    }
}
