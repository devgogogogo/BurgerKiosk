# 🍔 BurgerKiosk

## 📌 프로젝트 소개

> WPF + MVVM 패턴으로 구현한 햄버거 키오스크 애플리케이션입니다.
> MES/스마트팩토리 개발자 취업을 목표로 실무에서 사용하는 기술 스택을 적용했습니다.
> 메뉴 선택 → 장바구니 → 주문 완료까지의 흐름을 구현하고, 관리자 화면에서 주문을 관리할 수 있습니다.

## 📌 목차

### 프로젝트 개요
- [① 프로젝트 소개](#-프로젝트-소개)
- [② 개발 기간](#-개발-기간)
- [③ 기술 스택](#-기술-스택)
- [④ 프로젝트 구조](#-프로젝트-구조)

### UI & 기능 소개
- [⑤ 주요 기능](#-주요-기능)
- [⑥ 화면 구성](#-화면-구성)

### 기타
- [⑦ 트러블슈팅](#-트러블슈팅)
- [⑧ 실행 방법](#-실행-방법)

## 📅 개발 기간

2026.04 ~ 2026.05

## 🛠 기술 스택

| 분류 | 기술 |
|------|------|
| UI | WPF (.NET 10) |
| 아키텍처 | MVVM 패턴 |
| DB | MSSQL (LocalDB) |
| ORM | Entity Framework Core 10 |
| DI | Microsoft.Extensions.Hosting |
| MVVM 라이브러리 | CommunityToolkit.Mvvm |
| 로깅 | Serilog (파일 + 콘솔) |
| 버전 관리 | Git / GitHub |

## 📁 프로젝트 구조

```
BurgerKiosk/
├── Data/
│   └── AppDbContext.cs          # EF Core DB 컨텍스트
├── Models/
│   ├── Menu.cs                  # 메뉴 엔티티
│   ├── Order.cs                 # 주문 엔티티
│   ├── OrderItem.cs             # 주문 항목 엔티티
│   └── CartItem.cs              # 장바구니 아이템 (임시 모델)
├── Repositories/
│   ├── MenuRepository.cs        # 메뉴 데이터 접근
│   └── OrderRepository.cs       # 주문 데이터 접근
├── Services/
│   ├── MenuService.cs           # 메뉴 비즈니스 로직
│   └── OrderService.cs          # 주문 비즈니스 로직
├── ViewModels/
│   ├── MenuViewModel.cs         # 메뉴 화면 ViewModel
│   ├── CartViewModel.cs         # 장바구니 화면 ViewModel
│   └── AdminViewModel.cs        # 관리자 화면 ViewModel
├── Views/
│   ├── MenuView.xaml            # 메뉴 선택 화면
│   ├── CartView.xaml            # 장바구니 화면
│   ├── OrderCompleteView.xaml   # 주문 완료 화면
│   └── AdminView.xaml           # 관리자 화면
├── logs/                        # Serilog 로그 파일
├── App.xaml.cs                  # DI 컨테이너 설정
└── appsettings.json             # DB 연결 문자열
```

## ✅ 주요 기능

- WPF + MVVM 패턴으로 UI 와 비즈니스 로직 분리
- EF Core + MSSQL 로 메뉴/주문 데이터 영구 저장
- DI + Repository Pattern 으로 계층 분리
- Serilog 로 날짜별 로그 파일 자동 생성

### 1. 메뉴 선택 화면
- DB 에서 메뉴 목록을 조회하여 화면에 표시
- 메뉴 버튼 클릭 시 장바구니에 자동 추가
- 같은 메뉴 클릭 시 수량 자동 증가
- 장바구니 보기 / 관리자 화면 이동 버튼

### 2. 장바구니 화면
- 담긴 메뉴 목록 및 총 금액 실시간 표시
- `+` / `-` 버튼으로 수량 변경
- 삭제 버튼으로 개별 메뉴 삭제
- 주문 완료 버튼 클릭 시 DB 에 저장 후 완료 화면으로 이동
- 뒤로가기 버튼으로 메뉴 화면으로 복귀

### 3. 주문 완료 화면
- 주문 완료 메시지 표시
- 확인 버튼 클릭 시 장바구니 화면 종료

### 4. 관리자 화면
- 전체 주문 목록 조회 (Read)
- 완료처리 버튼으로 주문 상태 변경 대기중 → 완료 (Update)
- 삭제 버튼으로 주문 삭제 (Delete)

## 📷 화면 구성

> 스크린샷 추가 예정

| 화면 | 설명 |
|------|------|
| MenuView | 메뉴 선택 화면 |
| CartView | 장바구니 화면 |
| OrderCompleteView | 주문 완료 화면 |
| AdminView | 관리자 주문 관리 화면 |

## 💡 트러블슈팅

### 1. AddScoped View 등록 시 닫힌 창 재사용 오류
- **문제** : 관리자 화면을 닫고 다시 열면 `InvalidOperationException` 발생
- **원인** : `AddScoped` 로 등록된 View 는 같은 객체를 재사용하기 때문에 닫힌 창을 다시 열려고 할 때 오류 발생
- **해결** : View 는 `AddTransient` 로 등록하여 호출할 때마다 새 창 생성

```csharp
// 변경 전
services.AddScoped<AdminView>();

// 변경 후
services.AddTransient<AdminView>();
```

### 2. MVVM 패턴에서 ViewModel 이 View 를 직접 띄우는 문제
- **문제** : 주문 완료 후 `OrderCompleteView` 를 띄워야 하는데 ViewModel 에서 View 를 직접 생성하면 MVVM 패턴 위반
- **원인** : ViewModel 은 View 를 몰라야 하는데 직접 참조하면 결합도가 높아짐
- **해결** : `event` 를 사용하여 ViewModel 이 이벤트를 발생시키고 View 에서 이벤트를 받아 화면 전환 처리

```csharp
// CartViewModel.cs — 이벤트 선언 및 발생
public event EventHandler? OrderCompleted;
OrderCompleted?.Invoke(this, EventArgs.Empty);

// CartView.xaml.cs — 이벤트 구독 및 처리
cartViewModel.OrderCompleted += OnOrderCompleted;
private void OnOrderCompleted(object? sender, EventArgs e)
{
    OrderCompleteView view = new OrderCompleteView();
    view.ShowDialog();
    this.Close();
}
```
### 3. List 로 바인딩 시 메뉴 추가해도 화면이 안 바뀌는 문제
 
- **문제** : 메뉴 버튼을 클릭해서 장바구니에 추가했는데 화면에 아무 변화가 없음
- **원인** : `List<T>` 는 데이터가 변경돼도 WPF 에 변경 사실을 알려주는 기능이 없음.
  WPF 바인딩은 데이터가 바뀌었다는 알림(`INotifyCollectionChanged`)을 받아야 화면을 다시 그리는데
  `List<T>` 는 이 기능을 구현하지 않아서 아무리 데이터를 추가해도 화면이 그대로 유지됨
- **해결** : `List<T>` 대신 `ObservableCollection<T>` 를 사용.
  `ObservableCollection<T>` 는 항목이 추가/삭제될 때마다 WPF 에 자동으로 알림을 보내서 화면이 즉시 갱신됨
```csharp
// 변경 전 — List 사용 (화면 자동 갱신 안 됨)
private List<CartItem> _cartItems = new();
 
// 변경 후 — ObservableCollection 사용 (화면 자동 갱신)
[ObservableProperty]
private ObservableCollection<CartItem> _cartItems = new();
```
 
---

### 4. async 없이 await 사용해서 컴파일 오류
 
- **문제** : `OrderRepository.cs` 에서 `await` 를 사용했는데 컴파일 오류 발생
  ```
  CS4033: 'await' 연산자는 비동기 메서드 내에서만 사용할 수 있습니다.
  ```
- **원인** : `await` 는 반드시 `async` 키워드가 붙은 메서드 안에서만 사용할 수 있음.
  `async` 없이 `await` 를 쓰면 컴파일러가 "이 메서드가 비동기 메서드인지 모르겠어" 라고 판단해서 오류 발생.
  인터페이스에서 `Task` 반환 타입만 보고 구현 클래스에서 `async` 를 빠트린 것이 원인
- **해결** : 메서드에 `async` 키워드 추가.
  `await` 를 사용하는 모든 메서드에는 반드시 `async` 가 있어야 함
```csharp
// 변경 전 — async 없이 await 사용 (컴파일 오류)
public Task<Order?> GetByIdAsync(int id)
{
    Order? order = await query.FirstOrDefaultAsync(o => o.Id == id); // 오류!
    return order;
}
 
// 변경 후 — async 추가 (정상)
public async Task<Order?> GetByIdAsync(int id)
{
    Order? order = await query.FirstOrDefaultAsync(o => o.Id == id); // 정상
    return order;
}
```
### 5. CommunityToolkit 자동 생성 커맨드를 빌드 전에 사용해서 오류
 
- **문제** : `MenuView.xaml.cs` 에서 `LoadMenusAsyncCommand` 를 호출했는데 오류 발생
  ```
  CS1061: 'MenuViewModel' 에는 'LoadMenusAsyncCommand' 에 대한 정의가 포함되어 있지 않습니다.
  ```
- **원인** : `[RelayCommand]` 어노테이션을 붙이면 `CommunityToolkit` 이 빌드 시점에 `LoadMenusAsyncCommand` 를 자동 생성함.
  빌드 전에는 이 코드가 아직 존재하지 않아서 컴파일러가 해당 커맨드를 찾지 못해 오류 발생.
  코드를 작성하는 시점에는 커맨드가 없고 빌드 후에야 생성되는 구조라서 생기는 문제
- **해결** : 솔루션을 한번 빌드하면 `CommunityToolkit` 이 커맨드를 자동 생성하므로 오류가 사라짐.
  또는 커맨드 대신 메서드를 직접 호출하는 방식으로 변경
```csharp
// 변경 전 — 빌드 전에 커맨드 사용 (오류)
await viewModel.LoadMenusAsyncCommand.ExecuteAsync(null);
 
// 변경 후 — 메서드 직접 호출 (정상)
await viewModel.LoadMenusAsync();
```
 
---

###  6. DataGridTemplateColumn 을 DataGrid.Columns 밖에 작성해서 화면에 안 나오는 문제
 
- **문제** : 관리자 화면에서 삭제 버튼 컬럼을 추가했는데 화면에 컬럼이 나타나지 않음
- **원인** : `DataGridTemplateColumn` 은 반드시 `DataGrid.Columns` 태그 안에 있어야 함.
  `DataGrid.Columns` 닫는 태그 밖에 작성하면 WPF 가 해당 컬럼을 `DataGrid` 의 컬럼으로 인식하지 못해서
  화면에 표시되지 않음. XAML 구조상 오류도 발생하지 않아서 찾기 어려운 문제
- **해결** : 삭제 버튼 컬럼을 `DataGrid.Columns` 닫는 태그 안쪽으로 이동
```xml
<!-- 변경 전 — DataGrid.Columns 밖에 작성 (화면에 안 나옴) -->
<DataGrid>
    <DataGrid.Columns>
        <DataGridTextColumn Header="주문번호"/>
    </DataGrid.Columns>
 
    <!-- ❌ Columns 밖에 있어서 인식 안 됨 -->
    <DataGridTemplateColumn Header="삭제">
        ...
    </DataGridTemplateColumn>
</DataGrid>
 
<!-- 변경 후 — DataGrid.Columns 안에 작성 (정상) -->
<DataGrid>
    <DataGrid.Columns>
        <DataGridTextColumn Header="주문번호"/>
 
        <!-- ✅ Columns 안에 있어서 정상 표시 -->
        <DataGridTemplateColumn Header="삭제">
            ...
        </DataGridTemplateColumn>
    </DataGrid.Columns>
</DataGrid>
```

## 🚀 실행 방법

1. Visual Studio 2022 이상 설치 (.NET 10 포함)
2. 프로젝트 클론
```bash
git clone https://github.com/devgogogogo/BurgerKiosk.git
```
3. `appsettings.json` 에서 DB 연결 문자열 확인
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BurgerKioskDb;Trusted_Connection=True;"
  }
}
```
4. 패키지 관리자 콘솔에서 실행
```
Update-Database
```
5. 빌드 후 실행 (`F5`)
