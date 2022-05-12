using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 데이터 베이스
public class ItemDB : MonoBehaviour
{
    public static ItemDB instance; // 다른 스크립트에서 접근
    public GameObject ItemPrefab;  // 프리팹 복제
    public Vector3[] pos;          // 아이템 생성위치

    public int money = 0;          // 플레이어 머니

    private void Awake()
    {
        instance = this; // 싱글턴
    }
    public List<Item> itemDB = new List<Item>(); // 아이템 리스트

    public void Start()
    {
        money = 100000; // 플레이어 머니 초기화

        // 반복문으로 아이템 생성
        // 생성된 fieldItem의 Item을 ItemDB중 한 개로 초기화
        //GameObject go;
        //go.GetComponent<ItemPickUp>().SetItem(itemDB[itemDB]);

        //for (int i = 0; i < 3; i++)
        //{
        //    GameObject go = Instantiate(ItemPrefab, pos[i], Quaternion.identity);
        //    go.GetComponent<ItemPickUp>().SetItem(itemDB[Random.Range(0, 3)]);
        //}
    }
}



