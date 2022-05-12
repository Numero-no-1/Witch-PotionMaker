using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
// item.cs 에셋을 참조할 스크립트
public class ItemPickUp : MonoBehaviour
{
    public Item item;            // 아이템 정보
    public SpriteRenderer image; // 아이템 이미지

    // 아이템 데이터 콘테이너
    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName;   // 아이템 이름
        item.itemImage = _item.itemImage; // 아이템 이미지
        item.itemType = _item.itemType;   // 아이템 타임
        item.itemCost = _item.itemCost;   // 아이템 가격
        item.efts = _item.efts;           // 아이템 효과

        image.sprite = _item.itemImage;// 아이템에 맞게 스프라이트 바꿔줌
    }

    // 콜라이더 충돌시 inventory에서 호출하여 AddItem(itemPickUp.GetItem()))
    public Item GetItem()
    {
        return item; // 아이템 정보 리턴
    }

    // 필드의 아이템 파괴
    public void DestroyItem()
    {
        Destroy(gameObject); // 호출되면 해당 아이템 파괴

    }
    // GetItem()에 의해 아이템 정보가 성공적으로 담기면, 필드의 아이템이 파괴된다.
}
