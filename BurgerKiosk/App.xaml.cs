using BurgerKiosk.Data;
using BurgerKiosk.Repositories;
using BurgerKiosk.Services;
using BurgerKiosk.ViewModels;
using BurgerKiosk.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace BurgerKiosk
{
    //WPF 앱이 시작될 때 가장 먼저 실행되는 파일이다. 
    // DI 컨테이너 설정, Serilog 설정
    // Serilog 는 로그를 파일/콘솔에 남겨주는 라이브러리
    public partial class App : Application
    {
        //IHost 는 DI 컨테이너를 담는 인터페이스예요.
        private IHost _host;

        public App()
        {
            // Serilog 설정
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()   // 콘솔에 로그 출력
                .WriteTo.File(
                    path: "logs/kiosk-.txt",    // 파일 경로 (- 뒤에 날짜 자동 붙음)
                    rollingInterval: RollingInterval.Day,  // 날짜별로 파일 분리
                    retainedFileCountLimit: 30)   // 최근 30일치만 보관
                .CreateLogger();

            // Host 설정
            _host = Host.CreateDefaultBuilder()  // DI 컨테이너 생성 시작
                .UseSerilog()  // Serilog 를 로그 시스템으로 등록
                .ConfigureAppConfiguration(config =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory()); // 현재 폴더 기준
                    config.AddJsonFile("appsettings.json");  // appsettings.json 읽기
                })
                .ConfigureServices((context, services) =>
                {
                    //자바로 따지면 여기가 Bean 등록하는 곳
                    // AppDbContext DI 등록
                    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection"))); // 연결문자열 읽기
                    // Repository 등록
                    services.AddScoped<MenuRepository>();
                    services.AddScoped<OrderRepository>();

                    // Service 등록
                    services.AddScoped<MenuService>();
                    services.AddScoped<OrderService>();

                    // ViewModel 등록
                    services.AddScoped<MenuViewModel>();

                    // View 등록
                    services.AddScoped<MenuView>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e) // 앱 시작할때 실행
        {
            await _host.StartAsync(); // DI 컨테이너 시작
            MenuView menuView = _host.Services.GetRequiredService<MenuView>();
            menuView.Show();
            base.OnStartup(e); // WPF 기본 시작 로직 실행
        }

        protected override async void OnExit(ExitEventArgs e) // 앱 종료할때 실행
        {
            await _host.StopAsync(); // DI 컨테이너 종료
            Log.CloseAndFlush(); // 로그 버퍼 비우기 (안 하면 마지막 로그 유실)
            base.OnExit(e);   // WPF 기본 종료 로직 실행
        }
    }
}
