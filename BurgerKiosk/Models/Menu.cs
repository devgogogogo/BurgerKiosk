using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BurgerKiosk.Models
{
    //키오스크 화면에 보여줄 메뉴
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [Required] //NULL 허용 안 함
        public string Name { get; set; } = string.Empty; // 메뉴이름

        [Required]//NULL 허용 안 함
        public int Price { get; set; } // 가격
        [Required]
        public string Category { get; set; } = string.Empty; // 버거/사이드/음료
        public bool IsAvailable { get; set; } = true; //품절 여부 — 기본값 true (판매중)

        public string ImagePath { get; set; } = string.Empty; // 이미지 경로

        public string Description { get; set; } = string.Empty; // 메뉴 설명
    }
}