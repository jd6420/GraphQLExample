using CoffeeShop.Data;
using CoffeeShop.Interfaces;
using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Services
{
    public class MenuService : IMenu
    {
        private readonly GraphQLDbContext _dbContext;

        public MenuService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Menu> AddMenu(Menu menu)
        {
            await _dbContext.AddAsync(menu);
            await _dbContext.SaveChangesAsync();
            return menu;
        }

        public List<Menu> GetMenus()
        {
            return _dbContext.Menus.ToList();
        }
    }
}
