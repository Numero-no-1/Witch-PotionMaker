//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//// �κ��丮 ���� ������ �̹���

//public class SlotItem : MonoBehaviour
//{
//    [SerializeField] Image image; // Image Component�� ���� ��
//    private Item _item;
//    public Item item {
//        get { return _item; } //������ item ������ �Ѱ��� �� ���
//        set { 
//            _item = value; //item�� ������ ������ ���� _item�� ����

//            // AddItem()�� FreshSlot() �Լ����� ���
//            if (_item != null) { 
//                image.sprite = item.itemImage; 
//                image.color = new Color(1, 1, 1, 1); 
//            }
//            else 
//            {
//                image.color = new Color(1, 1, 1, 0); 
//            }
//            // ���� Inventory.cs �� List<Item> items�� ��ϵ� �������� �ִٸ�
//            // temImage�� image�� ���� �׸��� Image�� ���� ���� 1�� �Ͽ� �̹����� ǥ���մϴ�.
//            // ���� item�� null �̸�(�󽽷� �̸�) Image�� ���� �� 0�� �־� ȭ�鿡 ǥ������ �ʽ��ϴ�.
//        } 
//    }
//}
#region
// ��ó: https://geojun.tistory.com/62 [Jungle(����)]
#endregion
