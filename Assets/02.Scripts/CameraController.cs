using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    

    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        // 카메라가 플레이어 따라오게 한다. z값에는 target 안붙여줌
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);      // 카메라 앵글 고정하기 위한것   (카메라 옮겨보고 그 값 입력해줌)
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
