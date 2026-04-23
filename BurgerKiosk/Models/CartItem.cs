using BurgerKiosk.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerKiosk.Models
{
    //[Key]를 사용하지 않는 이유: CartItem 클래스는 DB에 저장되는 엔티티가 아니라,
    //주문 과정에서 일시적으로 사용되는 모델이기 때문입니다.
    //CartItem은 사용자가 메뉴를 선택할 때마다 생성되고, 주문이 완료되면 사라지는 임시 객체입니다.
    public partial class CartItem : ObservableObject
    {
        public Menu Menu { get; set; } = null!; // 메뉴 정보

        [ObservableProperty]
        private int _quantity = 1; // 수량 - 기본값 1

        // 총 금액 — CartItems 가 바뀔 때마다 계산
        public int TotalPrice
        {
            get
            {
                return Menu.Price * Quantity;
            }
        }
        //public int TotalPrice => Menu.Price * Quantity; 이건 람다식 표현으로 TotalPrice 계산하는 방법.
        //위와 같은 결과지만 코드가 더 간결해짐
    }
}

//partial 이 없으면
//CartItem.cs          ← 우리가 작성한 코드
//CartItem.g.cs        ← CommunityToolkit 이 자동 생성한 코드

//partial 없음 → 두 파일을 하나의 클래스로 합칠 수 없음 → 오류
//partial 있음 → 두 파일이 하나의 클래스로 합쳐짐 → 정상
