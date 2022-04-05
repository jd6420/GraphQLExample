using CoffeeShop.Models;
using GraphQL.Types;

namespace CoffeeShop.Type
{
    public class SubmenuType : ObjectGraphType<Submenu>
    {
        public SubmenuType()
        {
            Field(p => p.Id);
            Field(p => p.Name);
            Field(p => p.Description);
            Field(p => p.ImageUrl);
            Field(p => p.Price);
            Field(p => p.MenuId);
        }
    }
}
