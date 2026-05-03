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

// 주문 완료 후 손님에게 주문이 완료됐다는 것을 알려주는 화면.
namespace BurgerKiosk.Views
{
    /// <summary>
    /// OrderCompleteView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OrderCompleteView : Window
    {
        public OrderCompleteView()
        {
            InitializeComponent();
        }

        //확인 버튼 클릭 - 현재 창 닫기
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
