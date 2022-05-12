using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ŀ�� �̹��� Ŀ����
public class ChangeCursor : MonoBehaviour
{
    [SerializeField] Texture2D cursorImg;

    void Start()
    {
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
    }

}
