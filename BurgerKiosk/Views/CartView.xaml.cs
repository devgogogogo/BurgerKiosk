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
        }
    }
}
