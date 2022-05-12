using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;           // UI 사용
using UnityEngine.EventSystems; // IPointerUpHandler 지원
// 최종 파일
// 플레이어 인벤토리 슬롯
public class Slot : MonoBehaviour, IPointerUpHandler // 마우스 화면 입력의 반응 처리
{
    public Item item;           // 아이템 정보
    public Image itemIcon;      // 아이템 이미지
    public int slotnum;         // 슬롯에 번호 부여

    public bool isShopMode;     // 아이템 참이면 sell out 거짓이면 use
    public bool isSell = false; // true 상테의 아이템만 sell out
    public GameObject chkSell;  // 플레이어 인벤에서 선택한 슬_게임 도중 비활성화/활성화 시킬 오브젝트는 GameObject 타입

    // 아이템 이미지 초기화, 활성화
    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;     // 아이템 이미지 스프라이트로 담음
        itemIcon.gameObject.SetActive(true);  // 스프라이트 활성화
    }

    // 슬롯 초기화. 아이템 정보 지움
    public void RemoveSlot()
    {
        item = null;                          // 아이템 정보 비움
        itemIcon.gameObject.SetActive(false); // 비활성화
    }

    // 마우스 클릭 후 함수 실행
    public void OnPointerUp(PointerEventData eventDate)
    {
        if (item != null)  // 슬롯에 아이템이 있을때만 실행
        {
            if (!isShopMode)            // 물약제조창 활성화 true 물약제조, false 아이템 사용_상점 거래모드가 아니면
            {
                bool isUse = item.Use(); // Slot에 있는 item.Use메서드 호출_아이템 사용
                if (isUse)               // 아이템 사용에 성공하면 RemoveItem 호출
                {
                    Inventory.instance.RemoveItem(slotnum); // 슬롯 초기화
                }
            }
            else
            {
                isSell = true;             // 클릭한 슬롯에 체크표시_inven에서 내보낼 아이템
                chkSell.SetActive(isSell); // 체크 이미지 활성화
            }
        }
    }

    // 아이템 판매. 인벤에서 아이템 sell out
    public void SellItem()
    {
        if (isSell) // 상점과 인벤이 같이 열려있을 때
        {
            ItemDB.instance.money += item.itemCost;  // 플레이어 money를 데이터 베이스에 지정된 가격만큼 추가
            Inventory.instance.RemoveItem(slotnum);  // 인벤토리에 소지한 아이템 중 같은 번호의 아이템 지움.
            
            isSell = false;            // 상점 거래 모드 종료
            chkSell.SetActive(isSell); // 체크 해제
        }
    }

    // 판매 버튼을 클릭하지 않고 상점을 닫을 때
    private void OnDisable()
    {
        isSell = false;             // 상점 거래 모드 종료
        chkSell.SetActive(isSell);  // 체크 이미지 비활성화
    }
}
