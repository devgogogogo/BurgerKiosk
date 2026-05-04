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
    /// AdminView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AdminView : Window
    {
        public AdminView(AdminViewModel adminViewModel)
        {
            InitializeComponent();
            // DataContext  - AdminView 가 바라볼 ViewModel 지정
            DataContext = adminViewModel;

        }

        // 닫기 버튼 클릭 - AdminView 닫기
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override async void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            // 화면이 렌더링되면 주문 목록 불러오기
            AdminViewModel viewModel = (AdminViewModel)DataContext;
            await viewModel.LoadOrdersAsync();
        }
    }
}
