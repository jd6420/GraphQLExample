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
        public MenuType()
        {
            Field(p => p.Id);
            Field(p => p.Name);
            Field(p => p.ImageUrl);
        }
    }
}
