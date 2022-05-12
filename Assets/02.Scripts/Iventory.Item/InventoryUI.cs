using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 사용

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;                    // 인벤토리의 부모
    public GameObject inventoryPanel;       // 게임 오브젝트
    bool activeInventory = false;           // 참이면 인벤토리 비활성화 막아줌

    public Slot[] slots;                    // 플레이어 인벤토리 슬롯 배열
    public Transform slotHolder;            // 플레이어 인벤토리 슬롯 묶음

    public LaboratorySlot[] laboratorySlot; // 상점 인벤토리 슬롯 배열
    public Transform shopHolder;            // 상점 인벤토리 슬롯 묶음

    void Start()
    {
        inventory = Inventory.instance; // 인벤토리 참조
        slots = slotHolder.GetComponentsInChildren<Slot>();                   // 슬롯 데이터 전부 담기_인벤토리
        laboratorySlot = shopHolder.GetComponentsInChildren<LaboratorySlot>(); // 상점 슬롯 데이터 전부 담기
        for (int i = 0; i < laboratorySlot.Length; i++) // 물약 상점 슬롯 채우기
        {
            laboratorySlot[i].Init(this);  // 상점 UI
            laboratorySlot[i].slotnum = i; // 상점 슬롯 순번
        }
        inventory.onSlotCountChange += SlotChange; // 인벤토리 슬롯 정보를 담고있는 델리게이트를 참조
        inventory.onChangeItem += RedrawSlotUI;    // 인벤토리 아이템 정보를 담고있는 델리게이트를 참조
        RedrawSlotUI();                            // 모든 슬롯 초기화
        inventoryPanel.SetActive(activeInventory);               // 인벤토리 패널 활성화
        closelaboratory.onClick.AddListener(DeActiveLaboratory); // 샵 패널 비활성화
    }

    // Inventory 델리게이트 참조해 슬롯 제어
    private void SlotChange(int val)
    {
        for (int i = 0; i < slots.Length; i++) // 슬롯의 길이만큼 반복
        {
            slots[i].slotnum = i;      // slotnum 부여
            if (i < inventory.SlotCnt) // Inventory 델리게이트가 가진 SlotCnt만큼 진행
            {
                slots[i].GetComponent<Button>().interactable = true;  // 슬롯 버튼 기능 활성화
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false; // SlotCnt 갯수 이상 비활성화
            }
        }
    }

    // 인벤토리 활성화 조건
    private void Update()
    {
        // 키보드 I가 입력되고, 물약 상점 패널이 비활성일 때
        if (Input.GetKeyDown(KeyCode.I) && !isLaboratoryActive)
        {
            activeInventory = !activeInventory;        // 인벤토리 활성 → 비활성
            inventoryPanel.SetActive(activeInventory); // 인벤토리 비활성 → 활성
        }
        if (Input.GetMouseButton(0)) // 마우스 버튼이 눌리면, 물약 상점 패널 활성화
        {
            RayLaboratory();         // 물약상점 위치 확인 메서드 호출
        }
    }

    // 슬롯 추가 버튼이 눌리면 슬롯 추가
    public void AddSlot()
    {
        inventory.SlotCnt = inventory.SlotCnt + 4;// 플레이어 인벤토리 슬롯 추가
    }

    // Inventory 델리게이트 참조해 아이템 개수만큼 슬롯 채우기
    void RedrawSlotUI()
    {
        for (int i = 0; i < slots.Length; i++) // 슬롯의 길이만큼 반복
        {
            slots[i].RemoveSlot();             // 아이템 들어오지 않은 슬롯 초기화
        }
        for (int i = 0; i < inventory.items.Count; i++)  // 인벤토리 아이템 개수만큼 아이템 추가
        {
            slots[i].item = inventory.items[i];          // 슬롯에 인벤토리 아이템 추가
            slots[i].UpdateSlotUI();                     // 아이템 스프라이트 그림
        }
    }

    public GameObject laboratory;         // 물약 상점
    public Button closelaboratory;        // 물약 상점 닫기
    public bool isLaboratoryActive;       // 물약 상점 활성화 제어 변수
    public LaboratoryData laboratoryData; // 물약상점 데이터

    // ray cast를 이용하여 물약 상점 위치 확인
    public void RayLaboratory()
    {
        // 마우스 포인터 위치를 기준으로 카메라의 월드(절대) 좌표 확인
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -10;  // 카메라 z좌표 -10

        //if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1))// 레이가 UI통과하지 못하게 막아줌
        //{// 레이가 UI통과하지 못하게 막아줌. 상점 비활성화 용도

        // 마우스 포인터 기준 Ray 앞으로 쏘기
        RaycastHit2D hit2D = Physics2D.Raycast(mousePos, transform.forward, 30);
        if (hit2D.collider != null)                      // ray의 충돌값이 있으면
        {
            if (hit2D.collider.CompareTag("Laboratory")) // 충돌체의 태그 확인
            {
                if (!activeInventory)                    // activeInventory가 false면
                {
                    ActiveLaboratory(true);              // activeInventory-> true_인벤토리 안닫힘
                    // 샵 클릭되면 LaboratoryData의 Component 가져옴
                    laboratoryData = hit2D.collider.GetComponent<LaboratoryData>();
                    for (int i = 0; i < laboratoryData.stocks.Count; i++) //LaboratoryData 아이템 수만큼 반복
                    {
                        laboratorySlot[i].item = laboratoryData.stocks[i]; // 상점의 아이템 데이터를 받아서 상점 슬롯에 채움.
                        laboratorySlot[i].UpdateSlotUI();                  // 아이템 sprite 활성화.
                    }
                }
                // 상점을 클릭하면 shopdata 가져오고, 아이템 보냄. -> 플레이어 인벤토리
                //shopData = hit2D.collider.GetComponent<ShopData>();
            }
        }
        // }
        //Debug.DrawRay(mousePos, transform.forward, Color.red, 0.5f);
    }

    // 상점의 팔린 아이템 데이터 정보 확인
    public void Buy(int num)
    {
        laboratoryData.soldOuts[num] = true;  // 팔린 아이템이 LaboratoryData의 몇 번째인지 확인하여 true. 이미지 제어
    }

    // 상점이 열릴 때, 플레이어 인벤토리 자동 열림
    public void ActiveLaboratory(bool isOpen)
    {
        //bool activeInventory = false;// 참이면 인벤토리 비활성화 막아줌
        if (!activeInventory) // activeInventory가 false이면
        {
            isLaboratoryActive = isOpen;           // 물약상점 활성화 참
            laboratory.SetActive(isOpen);          // 물약 상점 패널 활성화
            inventoryPanel.SetActive(isOpen);      // 인벤토리 패널 활성화
            for (int i = 0; i < slots.Length; i++) // 플레이어 인벤토리 길이만큼 반복
            {
                slots[i].isShopMode = isOpen;      // 플레이어 인벤토리 슬롯을 상점 거래모드로 바꿈
            }
        }
    }

    // 상점을 닫으면, 인벤토리 모든 정보 초기화
    public void DeActiveLaboratory()
    {
        ActiveLaboratory(false);  // 상점 닫음
        laboratoryData = null;    // 상점 데이터와 연결 끊기
        for (int i = 0; i < laboratorySlot.Length; i++)  // 상점 슬롯 길이만큼 반복
        {
            laboratorySlot[i].RemoveSlot();               // 물약 상점 정보 초기화_ 솔드아웃 정보 지움
        }
    }

    // 플레이어 인벤토리 판매 버튼
    public void SellBtn()
    {
        for (int i = slots.Length; i > 0; i--)
        {
            slots[i - 1].SellItem();  // 플레이어 인벤토리 슬롯 앞 부분부터 SellItem()메서드 호출_아이템 지움
        }
    }
}
