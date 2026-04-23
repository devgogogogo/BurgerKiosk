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
    public partial class MenuViewModel : ObservableObject
    {

        private readonly MenuService _menuService;
        private readonly CartViewModel _cartViewModel; // 장바구니 ViewModel 주입
        public MenuViewModel(MenuService menuService,CartViewModel cartViewModel)
        {
            _menuService = menuService;
            _cartViewModel = cartViewModel;
        }

        // ObservableCollection — 리스트가 바뀌면 화면에 자동으로 알림
        [ObservableProperty]
        private ObservableCollection<Menu> _menus = new();

        // [RelayCommand] — 메서드를 커맨드로 자동 생성
        // LoadMenusAsyncCommand 로 XAML 에서 바인딩 가능
        [RelayCommand]
        public async Task LoadMenusAsync()
        {
            List<Menu> menus = await _menuService.GetAllMenusAsync();
            Menus = new ObservableCollection<Menu>(menus);
        }

        // 메뉴 버튼 클릭 — 장바구니에 메뉴 추가
        [RelayCommand]
        private void AddToCart(Menu menu)
        {
            _cartViewModel.AddItem(menu);
        }
    }
}

/*
 [ObservableProperty] 동작 원리
 
 [ObservableProperty]
 private ObservableCollection<Menu> _menus = new();
 
 CommunityToolkit 이 자동 생성:
 public ObservableCollection<Menu> Menus
 {
     get => _menus;
     set { _menus = value; OnPropertyChanged(nameof(Menus)); }
 }
 
 명명 규칙: _menus → Menus / menus → Menus (둘 다 가능, _ 사용이 C# 관례)
*/