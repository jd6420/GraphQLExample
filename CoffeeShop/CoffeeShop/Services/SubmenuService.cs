using CoffeeShop.Data;
using CoffeeShop.Interfaces;
using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Services
{
    public class SubmenuService : ISubmenu
    {
        private readonly GraphQLDbContext _dbContext;

        public SubmenuService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Submenu> AddSubmenu(Submenu submenu)
        {
            await _dbContext.Submenus.AddAsync(submenu);
            await _dbContext.SaveChangesAsync();
            return submenu;
        }

        public List<Submenu> GetSubmenus(int menuId)
        {
            return _dbContext.Submenus.Where(x => x.MenuId == menuId).ToList();
        }

        public List<Submenu> GetSubmenus()
        {
            return _dbContext.Submenus.ToList();
        }
    }
}
