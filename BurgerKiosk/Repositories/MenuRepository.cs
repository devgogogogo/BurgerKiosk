using BurgerKiosk.Data;
using BurgerKiosk.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerKiosk.Repositories
{
    public class MenuRepository 
    {
        //readonly 는 final = readonly
        private readonly AppDbContext _context; // DB 컨텍스트 필드 선언

        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Menu>> GetAllAsync()
        {
            return await _context.Menus.ToListAsync();
        }

        public async Task<Menu?> GetByIdAsync(int id)
        {
            return await _context.Menus.FindAsync(id);
        }
    }
}
