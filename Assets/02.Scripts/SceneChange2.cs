using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("Main");
    }

    // Update is called once per frame
    public void ChangSecondScene()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
