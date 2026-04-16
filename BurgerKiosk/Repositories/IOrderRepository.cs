using BurgerKiosk.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerKiosk.Repositories
{
    public interface IOrderRepository
    {

        Task<List<Order>> GetAllAsync();// 주문 전체 목록 조회 — 관리자 화면에서 주문 목록 볼 때
        Task<Order?> GetByIdAsync(int id); // 특정 주문 1개 조회 — 주문 상세 볼 때
        Task CreateOrderAsync(Order order); //새 주문 추가 — 손님이 주문 완료할 때
        Task UpdateOrderAsync(Order order); //주문 수정 — 주문 상태 변경할 때 (대기중 → 완료)

        //비동기 : 작업이 끝날 때까지 기다리지 않고 다른 작업을 계속 하는 방식이에요.
    }
}
