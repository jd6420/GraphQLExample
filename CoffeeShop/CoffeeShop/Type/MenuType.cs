using CoffeeShop.Interfaces;
using CoffeeShop.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Type
{
    public class MenuType : ObjectGraphType<Menu>
    {
        public MenuType(ISubmenu submenuService)
        {
            Field(p => p.Id);
            Field(p => p.Name);
            Field(p => p.ImageUrl);
            Field<ListGraphType<SubmenuType>>("submenus", resolve: context => { return submenuService.GetSubmenus(context.Source.Id); });
        }
    }
}
