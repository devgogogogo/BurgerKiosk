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

        public MenuViewModel(MenuService menuService)
        {
            _menuService = menuService;
        }

        // [ObservableProperty] — _ 소문자 필드 선언하면
        // CommunityToolkit 이 대문자 프로퍼티(Menus) 자동 생성
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
    }
}

/*
 [ObservableProperty] 동작 원리
 
 우리가 작성:
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