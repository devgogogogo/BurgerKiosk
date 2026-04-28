using BurgerKiosk.Models;
using BurgerKiosk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BurgerKiosk.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        private readonly OrderService _orderService;

        public CartViewModel(OrderService orderService)
        {
            _orderService = orderService;
        }

        // 장바구니에 담긴 메뉴 목록
        [ObservableProperty]
        private ObservableCollection<CartItem> _cartItems = new();

        // 총 금액 — CartItems 가 바뀔 때마다 자동 계산
        public int TotalPrice
        {
            get
            {
                int total = 0;
                foreach (CartItem item in CartItems)
                {
                    total += item.TotalPrice;
                }
                return total;
            }
        }
        // 메뉴 추가 — 이미 담긴 메뉴면 수량만 증가, 없으면 새로 추가
        public void AddItem(Menu menu)
        {
            // 같은 메뉴를 찾았는지 여부
            bool found = false;

            // 장바구니 전체 순회
            foreach (CartItem item in CartItems)
            {
                // 같은 메뉴 찾으면
                if (item.Menu.Id == menu.Id)
                {
                    // 수량 증가
                    item.Quantity++;
                    found = true;
                    break;
                }
            }

            // 못 찾았으면 새로 추가
            if (found == false)
            {
                CartItems.Add(new CartItem { Menu = menu });
            }

            OnPropertyChanged(nameof(TotalPrice));
            //OnPropertyChanged("TotalPrice"); 해도 되지만 나중에 TotalPrice 이름 바꾸면 이 문자열도 직접 찾아서 바꿔야 함
            //OnPropertyChanged--> 화면에 "이 프로퍼티 값이 바뀌었어, 다시 그려줘" 라고 알려주는 메서드예요.
        }

        // 메뉴 삭제
        [RelayCommand]
        private void RemoveItem(CartItem item)
        {
            CartItems.Remove(item);
            OnPropertyChanged(nameof(TotalPrice));
        }
        // CommunityToolkit 이 자동 생성
        //public IRelayCommand RemoveItemCommand { get; } 가 자동생성
        // 메서드 이름 RemoveItem → RemoveItemCommand 로 자동 생성

        //수량증가 
        [RelayCommand]
        private void IncreaseQuantity(CartItem item)
        {
            item.Quantity++;
            OnPropertyChanged(nameof(TotalPrice));
        }
        //수량감소
        [RelayCommand]
        private void DecreaseQuantity(CartItem item)
        {
            //수량이 1이하면 삭제
            if (item.Quantity <= 1)
            {
                CartItems.Remove(item);

            }
            else
            {
                item.Quantity--;
            }
            OnPropertyChanged(nameof(TotalPrice));
        }

        // 주문 완료
        [RelayCommand]
        private async Task CompleteOrderAsync()
        {
            // 1. 장바구니 아이템을 OrderItem 리스트로 변환
            List<OrderItem> orderItems = new List<OrderItem>();

            // 2. CartItem → OrderItem 변환 (DB 에 저장할 형태로)
            foreach (CartItem item in CartItems)
            {
                OrderItem orderItem = new OrderItem
                {
                    MenuId = item.Menu.Id,
                    Quantity = item.Quantity,
                    UnitPrice = item.Menu.Price
                };
                orderItems.Add(orderItem);
            }

            // 3. Order 객체 생성
            Order order = new Order
            {
                OrderedAt = DateTime.Now,
                Status = "대기중",
                TotalPrice = TotalPrice,
                OrderItems = orderItems
            };
            // 4. DB 에 주문 저장
            await _orderService.CreateOrderAsync(order);
            // 5. 주문 완료 후 장바구니 비우기
            CartItems.Clear();
            // 6. TotalPrice 화면 업데이트 (장바구니 비웠으니 0 으로)     
            // OnPropertyChanged → 화면에 "이 프로퍼티 값이 바뀌었어, 다시 그려줘" 라고 알려주는 메서드
            OnPropertyChanged(nameof(TotalPrice));
        }
    }
}
