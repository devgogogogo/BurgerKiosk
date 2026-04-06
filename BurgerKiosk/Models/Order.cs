using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BurgerKiosk.Models
{
    //주문정보
    public class Order
    {
        [Key] //기본키
        public int Id { get; set; }

        [Required] //NULL 허용 안 함
        public DateTime OrderedAt { get; set; } = DateTime.Now; //주문시간

        [Required] //Null 허용안함
        public string Status { get; set; } = "대기중"; // 주문상태

        public int TotalPrice { get; set; } // 총 금액
        public List<OrderItem> OrderItems { get; set; } = new(); // 주문 아에 담긴 메뉴 목록

    }
}
