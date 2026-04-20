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

        // Seed 데이터 — DB 처음 만들 때 자동으로 들어가는 초기 데이터
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().HasData(
                new Menu { Id = 1, Name = "불고기버거", Price = 5000, Category = "버거", IsAvailable = true },
                new Menu { Id = 2, Name = "치즈버거", Price = 4500, Category = "버거", IsAvailable = true },
                new Menu { Id = 3, Name = "새우버거", Price = 4000, Category = "버거", IsAvailable = true },
                new Menu { Id = 4, Name = "콜라", Price = 2000, Category = "음료", IsAvailable = true },
                new Menu { Id = 5, Name = "사이다", Price = 2000, Category = "음료", IsAvailable = true },
                new Menu { Id = 6, Name = "감자튀김", Price = 2500, Category = "사이드", IsAvailable = true },
                new Menu { Id = 7, Name = "양파링", Price = 2500, Category = "사이드", IsAvailable = true }
            );
        }
    }

}
