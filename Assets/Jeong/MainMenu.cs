using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnClickNewGame()
    {
        Debug.Log("새 게임");
    }

     public void OnClickLoad()
    {
        Debug.Log("불러오기");
    }

    public void OnClickOption()
    {
        Debug.Log("옵션");
    }
    // 이 함수는 에디터에서 작동하지 않음
    // #if 라는 전처리기 지시문으로 UNITY_EDITOR 
    // 유니티 에디터에서 실행중일 때는 UnityEditor.EditorApplication.isPlaying을 false로 만들어서
    // _플레이 상태를 중단시키도록 만듬.
    public void OnClickQuit ()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
          Application.Quit();
#endif
    }






}
