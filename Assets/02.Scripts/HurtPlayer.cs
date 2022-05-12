using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private HealthManager healthManager;
    public float waitToHurt = 2f;
    public bool isTouching;
    [SerializeField]
    private int damageToGive = 10;      // 데미지 수치 정할수있음
    
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    
    void Update()
    {
        //if (reloading)
        //{
        //    waitToLoad -= Time.deltaTime;
        //    if (waitToLoad <= 0)
        //    {
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);          // 죽더라도 다시 시작하게함
        //    }
        //}

        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthManager.HurtPlayer(damageToGive);
                waitToHurt = 2f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            //Destroy(other.gameObject);        // 오류뜬다. 할당해둔 플레이어 사라져서
            //other.gameObject.SetActive(false);      // 사라지게 해둠
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
            //reloading = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }
}
