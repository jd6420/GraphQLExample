using CoffeeShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShop.Interfaces
{
    public interface IMenu
    {
        List<Menu> GetMenus();
        Task<Menu> AddMenu(Menu menu);
    }
}
