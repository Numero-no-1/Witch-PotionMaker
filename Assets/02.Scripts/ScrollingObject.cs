using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 오브젝트를 계속 왼쪽으로 움직이게
public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f; //이동 속도

    private void Update()
    {
        //게임 오브젝트를 일정 속도로 왼쪽으로 평행이동하게...(초당 speed으이 속도로)
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
