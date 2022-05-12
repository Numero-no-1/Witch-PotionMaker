using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PAUSE button
public class uiBtn : MonoBehaviour
{
    bool m_bPause;

    public void Pause()
    {
        if (m_bPause == false)
        {
            Time.timeScale = 0; //정지(버튼을 눌렀을 때)
            this.m_bPause = true;
        }
        else
        {
            Time.timeScale = 1; //정상속도로 플레이(버튼을 다시 한 번 눌렀을 때)
            this.m_bPause = false;
        }
    }
}
