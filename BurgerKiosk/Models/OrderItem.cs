using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BurgerKiosk.Models
{
    public class OrderItem //주문건
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Order")]// "Order 라는 네비게이션 프로퍼티랑 연결해줌" 밑에있는 Order (타입말고 프로퍼티 이름명)과 일치 시켜야함
        public int OrderId { get; set; }

        [ForeignKey("Menu")]
        public int MenuId { get; set; }

        [Required]
        public int Quantity { get; set; } //수량
        [Required]
        public int UnitPrice { get; set; } // 주문 당시 가격

        public Order Order { get; set; } = null!;//null 면제 연산자 -->"지금은 null 이지만 나중에 EF Core 가 채워줄 거니까 경고 무시해" 라는 뜻
        public Menu Menu { get; set; } = null!; // 네비게이션 프로퍼티 -->연관된 객체에 바로 접근할 수 있게 해주는 프로퍼티이다.
        //우리가 null! 을 쓰는 이유
        // 처음엔 null 이지만
        // EF Core 가 DB 에서 조회할 때 자동으로 채워줌
        // 그러니까 실제로 쓸 때는 null 이 아님
        // 컴파일러한테 "내가 책임질게, 경고 끄줘" 라고 하는 것
    }
}
