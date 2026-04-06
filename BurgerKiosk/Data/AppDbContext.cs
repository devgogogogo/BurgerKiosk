using BurgerKiosk.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerKiosk.Data
{
    public class AppDbContext : DbContext //EF Core 의 DbContext 상속
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } //연결문자열 등 설정값 받는 곳
        public DbSet<Menu> Menus { get; set; } //Menu 클래스 → Menus 테이블로 매핑
        public DbSet<Order> Orders { get; set; } //Order 클래스 → Orders 테이블로 매핑
        public DbSet<OrderItem> OrderItems { get; set; } // OrderItem 클래스 → OrderItems 테이블로 매핑
    }
}
