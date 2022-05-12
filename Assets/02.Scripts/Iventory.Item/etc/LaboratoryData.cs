using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 물약상점 아이템 데이터
public class LaboratoryData : MonoBehaviour
{
    public List<Item> stocks = new List<Item>(); // 상점의 아이템 리스트
    public bool[] soldOuts;                      // 팔린 아이템 정보 담을 배열_ 판매되면 true

    void Start()
    {
        // ItemDB의 아이템 넣음.
        stocks.Add(ItemDB.instance.itemDB[0]);
        stocks.Add(ItemDB.instance.itemDB[1]);
        stocks.Add(ItemDB.instance.itemDB[2]);
        //stocks.Add(ItemDB.instance.itemDB[3]);
        //stocks.Add(ItemDB.instance.itemDB[4]);
        //stocks.Add(ItemDB.instance.itemDB[5]);
        //stocks.Add(ItemDB.instance.itemDB[6]);
        //stocks.Add(ItemDB.instance.itemDB[7]);
        //stocks.Add(ItemDB.instance.itemDB[8]);
        //stocks.Add(ItemDB.instance.itemDB[9]);
        soldOuts = new bool[stocks.Count]; // 팔린 아이템의 배열 정보 담음

        // 상점이 열릴때, 아이템 이 담김_배열을 리스트의 크기만큼 초기화.
        for (int i = 0; i < soldOuts.Length; i++)
        {
            soldOuts[i] = false;  // 전부 거짓으로 초기화
        }

    }
}
