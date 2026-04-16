using BurgerKiosk.Models;
using BurgerKiosk.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerKiosk.Services
{
    public class MenuService
    {
        private readonly MenuRepository _menuRepository;
        private readonly ILogger<MenuService> _logger;

        public MenuService(MenuRepository menuRepository, ILogger<MenuService> logger)
        {
            _menuRepository = menuRepository;
            _logger = logger;
        }

        public async Task<List<Menu>> GetAllMenusAsync()
        {
            _logger.LogInformation("메뉴 전체 목록 조회 시작");
            List<Menu> menus = await _menuRepository.GetAllAsync();
            _logger.LogInformation("메뉴 전체 목록 조회 완료 - 총 {Count}개", menus.Count);
            return menus;
        }

        public async Task<Menu?> GetMenuByIdAsync(int id)
        {
            _logger.LogInformation("메뉴 조회 시작 - MenuId: {Id}", id);
            Menu? menu = await _menuRepository.GetByIdAsync(id);

            if (menu == null)
            {
                _logger.LogWarning("메뉴 없음 - MenuId: {Id}", id);
            }

            return menu;
        }
    }
}
