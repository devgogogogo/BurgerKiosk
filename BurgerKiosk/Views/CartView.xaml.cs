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

namespace BurgerKiosk.Views
{
    /// <summary>
    /// CartView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CartView : Window
    {
        public CartView(CartViewModel cartViewModel)
        {
            InitializeComponent();
            // DataContext — CartView 가 바라볼 ViewModel 지정
            DataContext = cartViewModel;

            //주문 완료 이벤트 구독
            // CartViewModel 에서 주문 완료되면 이 메서드 실행
            cartViewModel.OrderCompleted += OnOrderCompleted;
        }

        // 뒤로가기 버튼 클릭 - CartView 닫기
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //현재 창 닫기
        }

        // 주문 완료 이벤트 처리 — OrderCompleteView 띄우기
        private void OnOrderCompleted(object? sender, EventArgs e)
        {
            OrderCompleteView orderCompleteView = new OrderCompleteView();
            orderCompleteView.ShowDialog(); // 모달 창으로 띄우기
            this.Close(); // OrderCompleteView 닫으면 CartView 도 닫기
        }
    }
}
