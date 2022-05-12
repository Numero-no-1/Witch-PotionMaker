using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ȿ�� ��ȭ. ��� ����
[CreateAssetMenu(menuName = "ItemEft/Consumable/Health")] // �޴��̸�
public class ItemHealingEft : ItemEffect
{
    public int healingPoint = 10; // ü�� �߰�
    public override bool ExecuteRole()
    {
        Debug.Log("PlayerHP Add:" + healingPoint);
        return true;
    }
}
