using BurgerKiosk.Data;
using BurgerKiosk.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerKiosk.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _context;

        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Menu>> GetAllAsync()
        {
            return await _context.Menus.ToListAsync();
        }

        public async Task<Menu?> GetBtIdAsync(int id)
        {
            return await _context.Menus.FindAsync(id);
        }
    }
}
