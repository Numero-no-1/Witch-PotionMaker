using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 효과 모델화. 기능 없음
[CreateAssetMenu(menuName = "ItemEft/Consumable/Health")] // 메뉴이름
public class ItemHealingEft : ItemEffect
{
    public int healingPoint = 10; // 체력 추가
    public override bool ExecuteRole()
    {
        Debug.Log("PlayerHP Add:" + healingPoint);
        return true;
    }
}
