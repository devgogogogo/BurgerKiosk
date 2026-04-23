using BurgerKiosk.Data;
using BurgerKiosk.Repositories;
using BurgerKiosk.Services;
using BurgerKiosk.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;

namespace BurgerKiosk.Views
{
    /// <summary>
    /// MenuView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuView : Window
    // partial = 클래스가 두 파일로 나뉘어 있다는 뜻
    // MenuView.xaml    → 화면 디자인
    // MenuView.xaml.cs → 화면 로직
    // 둘이 합쳐져서 하나의 클래스가 됨
    {
        public MenuView(MenuViewModel menuViewModel)
        {
            // DataContext — View 가 바라볼 ViewModel 지정
            InitializeComponent();
            DataContext = menuViewModel;
        }

        protected override async void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            // 화면이 완전히 렌더링된 후에 메뉴 로드
            MenuViewModel viewModel = (MenuViewModel)DataContext;
            await viewModel.LoadMenusAsync();
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            // DI 컨테이너에서 CartView 꺼내서 화면 띄우기
            CartView cartView = App.ServiceProvider.GetRequiredService<CartView>();
            cartView.Show();
        }
    }
}
