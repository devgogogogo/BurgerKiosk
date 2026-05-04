using BurgerKiosk.Models;
using BurgerKiosk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;

namespace BurgerKiosk.ViewModels
{
    public partial class AdminViewModel : ObservableObject
    {
        private readonly OrderService _orderService;

        public AdminViewModel(OrderService orderService)
        {
            _orderService = orderService;
        }

        //주문 목록
        [ObservableProperty]
        private ObservableCollection<Order> _orders = new();


        //주문 목록 불러오기
        public async Task LoadOrdersAsync()
        {
            List<Order> orders = await _orderService.GetAllOrdersAsync();
            Orders = new ObservableCollection<Order>(orders);
        }

        //주문 상태 완료 처리
        [RelayCommand]
        private async Task CompleteOrder(Order order)
        {
            await _orderService.UpdateOrderStatusAsync(order.Id, "완료");
            await LoadOrdersAsync(); //목록 새로고침
        }

        //주문 삭제
        [RelayCommand]
        private async Task DeleteOrder(Order order)
        {
            await _orderService.DeleteOrderAsync(order.Id);
            await LoadOrdersAsync(); //목록 새로고침
        }
    }
}





//await _orderService.GetAllOrdersAsync(); 멈춤이라고 표현했지만 사실 동작중.
//이부분이 작동하는동안 다른 작업도 움직이고있음 다 끝나면 다시 일루 돌아옴.
//Task는 비동기 작업을 나타내는 객체로, 작업이 완료될 때까지 기다릴 수 있도록 해줌.