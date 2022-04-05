using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Type
{
    public class SubmenuInputType : InputObjectGraphType
    {
        public SubmenuInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("description");
            Field<StringGraphType>("imageUrl");
            Field<FloatGraphType>("price");
            Field<IntGraphType>("menuId");
        }
    }
}
