using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngeine.SceneManagement �� �߰��ؼ�
// SceneManager.LoadScene�� �̿��� �� ��ȯ�� �� �� �ִ�.

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
