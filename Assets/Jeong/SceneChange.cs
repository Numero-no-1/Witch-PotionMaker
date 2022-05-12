using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngeine.SceneManagement 를 추가해서
// SceneManager.LoadScene을 이용해 씬 전환을 할 수 있다.

public class SceneChange : MonoBehaviour
{
    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("FirstScenes");
    }    

    public void ChangeSecondScene ()
    {
        SceneManager.LoadScene("House");

    }

}
