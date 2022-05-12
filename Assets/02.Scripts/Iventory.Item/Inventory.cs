using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI사용

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnSlotcountChage(int val); // 슬롯 정보 delegate
    public OnSlotcountChage onSlotCountChange;      // 대리자 인스턴스

    public delegate void OnChangeItem();            // 아이템 정보 delegate
    public OnChangeItem onChangeItem;               // 대리자
    public List<Item> items = new List<Item>();     // 획득 아이템 담을 리스트
    public Sprite itemImage;                        // 아이템 스프라이트
    public GameObject go;                           // 게임오브젝트

    [SerializeField]
    private Text actionText;                        // 행동을 보여 줄 텍스트

    private int slotCnt;                            // 슬롯갯수
    public int SlotCnt
    {
        get => slotCnt;                        // 슬롯의 정보를 가져오고
        set
        {
            slotCnt = value;                   // 슬롯 정보 set
            onSlotCountChange.Invoke(slotCnt); // 델리게이트 다음 사용까지 대기_슬롯 정보 담고 있음
        }
    }

    void Start()
    {
        slotCnt = 12; // 초기 슬롯 갯수
    }

    // ItemPickUP.cs의 GetItem() 아이템 정보 담고 있음
    public bool AddItem(Item _item)
    {
        if (items.Count < SlotCnt) // 아이템 수가 슬롯보다 적으면
        {
            items.Add(_item);      // 아이템 정보 추가
            Debug.Log(_item.itemName);
            Debug.Log("Inventory.cs AddItem");

            //actionText.gameObject.SetActive(true);
            if (onChangeItem != null) // 델리게이트에 데이터가 있으면
            {
                Debug.Log("Add Item On!");
                onChangeItem.Invoke(); // 정보를 담은 델리게이트 대기
            }
            else Debug.Log("No game object");
            return true;
        }
        return false; // 슬롯이 꽉 차면 false반환
    }

    // 아이템 지우기
    public void RemoveItem(int _index)
    {
        items.RemoveAt(_index); // 인덱스에 맞는 아이템 속성 제거
        onChangeItem.Invoke();  // 온체인지 호출. 화면 다시 그림
    }

    // 아이템 정보 획득
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item")) // 충돌한 Collider의 태그가 "Item"이면
        {
            // 충돌체의 게임오브젝트의 ItemPickUP Component를 가져와 담기
            ItemPickUp collObject = collision.gameObject.GetComponent<ItemPickUp>();
            Item tagObject = collObject.item;      // 충돌체의 아이템 정보 담기
            if (collObject != null)                // 충돌체의 정보를 가져왔으면
            {
                Debug.Log(tagObject.itemName);
                Debug.Log("Inventory.cs OnTriggerEnter2D");
                
                if (AddItem(collObject.GetItem())) //ItemPickUP.cs의 GetItem() 아이템 정보로 AddItem()메서드 호출
                {
                    collObject.DestroyItem();      // 정보가 성공적으로 담기면, 필드의 아이템 파괴
                }
            }
            else
            {
                Debug.Log("No found");
            }
        }
    }
}
