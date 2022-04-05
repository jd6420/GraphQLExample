using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Interfaces
{
    public interface ISubmenu
    {
        List<Submenu> GetSubmenus();
        List<Submenu> GetSubmenus(int menuId);
        Task<Submenu> AddSubmenu(Submenu submenu);
    }
}
