using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive = 2;        // 플레이어가 몬스터에게 가할 피해량

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //Destroy(other.gameObject);      // 테스트한것 히트박스에 맞으면 죽음
            EnemyHealthManager eHealthManager;
            eHealthManager = other.gameObject.GetComponent<EnemyHealthManager>();
            eHealthManager.HurtEnemy(damageToGive);
        }

        if (other.tag == "Boss")
        {
            //Destroy(other.gameObject);      // 테스트한것 히트박스에 맞으면 죽음
            BoEnemyHealthManager eHealthManager;
            eHealthManager = other.gameObject.GetComponent<BoEnemyHealthManager>();
            eHealthManager.HurtEnemy(damageToGive);
        }
    }
}
