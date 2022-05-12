using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransitions : MonoBehaviour
{
    private CameraController cam;

    public Vector2 newMinPos;       // 새로운 카메라 위치
    public Vector2 newMaxPos;
    public Vector3 movePlayer;      // 위의 처리만 해주면 왼쪽가면 오른쪽 고정 오른쪽가면 왼쪽 고정됨

    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cam.minPosition = newMinPos;
            cam.maxPosition = newMaxPos;
            other.transform.position += movePlayer;
        }
    }
}
