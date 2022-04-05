using CoffeeShop.Interfaces;
using CoffeeShop.Models;
using CoffeeShop.Type;
using GraphQL;
using GraphQL.Types;

namespace CoffeeShop.Mutation
{
    public class MenuMutation : ObjectGraphType
    {
        public MenuMutation(IMenu menuService)
        {
            Field<MenuType>("createMenu",
                arguments: new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu" }),
                resolve: context => { return menuService.AddMenu(context.GetArgument<Menu>("menu")); });
        }
    }
}
