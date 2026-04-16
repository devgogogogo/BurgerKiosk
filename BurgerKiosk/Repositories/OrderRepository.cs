using BurgerKiosk.Data;
using BurgerKiosk.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerKiosk.Repositories
{
    public class OrderRepository 
    {
        private readonly AppDbContext _context; //readonly는 final 같은 것임

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            IQueryable<Order> query = _context.Orders
                 .Include(o => o.OrderItems)
                 .ThenInclude(oi => oi.Menu);
            List<Order> orders = await query.ToListAsync();
            return orders;
        }

       


        //async 가 없으면 await 을 사용할수 없다 . 
        public async Task<Order?> GetByIdAsync(int id)
        {
            IQueryable<Order> query = _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Menu);

            Order? order = await query.FirstOrDefaultAsync(o => o.Id == id);

            return order;
        }
        public async Task CreateOrderAsync(Order order)
        {
            //_context.Orders.Add(order); 이것도 결과는 같지만 이건 -->동기
            await _context.Orders.AddAsync(order); // 주문 추가 -->이건 비동기
            await _context.SaveChangesAsync();// DB 에 반영 여기서 실제 DB 에 INSERT
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);         // 주문 수정
            await _context.SaveChangesAsync();     // DB 에 반영
        }
    }
}
