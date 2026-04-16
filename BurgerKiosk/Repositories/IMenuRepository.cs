using BurgerKiosk.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerKiosk.Repositories
{
    public interface IMenuRepository
    {

        Task<List<Menu>> GetAllAsync(); //메뉴 전체 목록 조회 — 키오스크 화면에 메뉴 목록 표시할 때
        Task<Menu?> GetBtIdAsync(int id); //특정 메뉴 1개 조회 — 주문할 때 메뉴 정보 가져올 때
    }
}
