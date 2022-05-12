using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치
public class BackgroundLoop : MonoBehaviour
{
    private float width; //배경의 가로 길이

    private void Awake()
    {
        //가로 길이를 측정하는 처리
        //박스콜라이더2d 컴퍼넌트의 sizw field x값을 가로 길이로
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    private void Update()
    {
        //현재 위치가 원점에서 왼쪽으로 width이상 이동했을 때 위치를 재배치
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }


    //위치를 재배치하는 메서드
    private void Reposition()
    {
        //현재 위치에서 오른쪽으로 가로 길이 *2 만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
