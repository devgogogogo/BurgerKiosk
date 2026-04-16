using BurgerKiosk.Models;
using BurgerKiosk.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerKiosk.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(OrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            _logger.LogInformation("주문 전체 목록 조회 시작");
            List<Order> orders = await _orderRepository.GetAllAsync();
            _logger.LogInformation("주문 전체 목록 조회 완료 - 총 {Count}개", orders.Count);
            return orders;
        }
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            _logger.LogInformation("주문 조회 시작 - OrderId: {Id}", id);
            Order? order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                _logger.LogWarning("주문 없음 - OrderId: {Id}", id);
            }

            return order;
        }

        public async Task CreateOrderAsync(Order order)
        {
            _logger.LogInformation("주문 생성 시작 - TotalPrice: {Price}", order.TotalPrice);
            await _orderRepository.CreateOrderAsync(order);
            _logger.LogInformation("주문 생성 완료 - OrderId: {Id}", order.Id);
        }

        public async Task UpdateOrderStatusAsync(int id, string status)
        {
            Order? order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                _logger.LogWarning("주문 없음 - OrderId: {Id}", id);
                return;
            }

            order.Status = status;
            await _orderRepository.UpdateOrderAsync(order);
            _logger.LogInformation("주문 상태 변경 완료 - OrderId: {Id}, Status: {Status}", id, status);
        }
    }
}
