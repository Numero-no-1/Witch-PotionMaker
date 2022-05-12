using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 커서 이미지 커스텀
public class ChangeCursor : MonoBehaviour
{
    [SerializeField] Texture2D cursorImg;

    void Start()
    {
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
    }

}
