using BurgerKiosk.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerKiosk.Repositories
{
    public interface IMenuRepository
    {
        //따로 Repository를 구현한 이유 
        //ViewModel 이나 Service 가 DB 에 직접 접근하면 나중에 DB 가 바뀌거나 테스트할 때 전체 코드를 수정해야 한다..
        //Repository 가 중간에서 DB 접근을 담당하면 나머지 코드는 DB 를 몰라도 돼요.
        Task<List<Menu>> GetAllAsync(); //메뉴 전체 목록 조회 — 키오스크 화면에 메뉴 목록 표시할 때
        Task<Menu?> GetBtIdAsync(int id); //특정 메뉴 1개 조회 — 주문할 때 메뉴 정보 가져올 때
        //Task는 DB 조회처럼 시간이 걸리는 작업을 비동기로 처리할때 쓰는 타입이다.
    }
}
