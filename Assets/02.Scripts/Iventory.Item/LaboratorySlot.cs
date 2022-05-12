using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;           // UI 사용
using UnityEngine.EventSystems; // IPointerUpHandler 지원

// 물약 상점 슬롯
public class LaboratorySlot : MonoBehaviour, IPointerUpHandler  // 마우스 화면 입력의 반응 처리
{
    public int slotnum;          // 슬롯에 번호 부여
    public Item item;            // 아이템 정보
    public Image itemIcon;       // 아이템 이미지
    public bool soldOut = false; // 물약상점 아이템의 판매된 아이템 체크
    InventoryUI inventoryUI;     // 플레이어 인벤토리

    // InventoryUI의 메소드 호출
    public void Init(InventoryUI Iui)
    {
        inventoryUI = Iui;  //InventoryUI의 메소드 사용 위한 선언
    }

    // 슬롯 아이템 이미지
    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;    // 아이템 스프라이트
        itemIcon.gameObject.SetActive(true); // 아이템 스프라이트 활성화

        if (soldOut)
            itemIcon.color = new Color(0.5f, 0.5f, 0.5f);
             // 아이템 판매되면 이미지 어둡게 만듬_soldOut TRUE
    }

    // 슬롯 초기화. 
    public void RemoveSlot()
    {
        item = null;                          // 아이템 정보 비우기
        soldOut = false;                      // 판매 모드 종료
        itemIcon.gameObject.SetActive(false); // 비활성화
    }

    // 마우스 클릭 후 함수 실행
    public void OnPointerUp(PointerEventData eventDate)
    {
        if (item != null) // 슬롯에 아이템 정보가 있을때만 실행
        {
            // ItemDB의 money가 item가격보다 많고, 아이템이 있으며, 구매 아이템이 플레이어 인벤토리 슬롯 수보다 적을 때 실행
            if (ItemDB.instance.money >= item.itemCost && !soldOut && Inventory.instance.items.Count < Inventory.instance.SlotCnt)
            {
                ItemDB.instance.money -= item.itemCost; // 아이템 가격만큼 ItemDB의 money 차감
                Inventory.instance.AddItem(item);       // 인벤토리 아이템 추가
                soldOut = true;                         // 아이템 이미지 어둡게
                inventoryUI.Buy(slotnum);               // 판매된 아이템 정보 확인 메서드 호출_몇 번째인지
                UpdateSlotUI();                         // 슬롯 다시 그림
            }

        }
    }
}
