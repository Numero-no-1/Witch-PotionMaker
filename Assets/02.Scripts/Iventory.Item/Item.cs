using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 ScriptableObject
// 모델 생성시 기본적으로 지어질 이름, create 메뉴 이름
[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject // 게임오브젝트에 붙일 필요 없음
{
    public enum ItemType// 아이템 유형
    {
        Equip,
        Use,
        Quest
    }


    public string itemName;       // 아이템 이름
    public ItemType itemType;     // 아이템 유형
    public Sprite itemImage;      // 아이템의 이미지_ Image 캔버스 에서만. Sprite 월드, 모든 곳
    public GameObject itemPrefab; // 아이템의 프리팹 (아이템 생성시 프리팹으로 찍어냄)

    public string weaponType;     // 무기유형. 임시

    public int itemCost;          //머니
    public List<ItemEffect> efts; // 아이템 효과

    // 아이템 사용 모드
    public bool Use()           
    {
        // 아이템 사용
        bool isUsed = false;             // 아이템 사용여부 확인
        foreach (ItemEffect eft in efts) // 반복문 돌려서 efts의 ExecuteRole 실행
        {
            isUsed = eft.ExecuteRole(); // 아이템 효과
        }

        return isUsed;                  // 반환 값
    }
}


