using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoHurtEnemy : MonoBehaviour
{
    public int damageToGive = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //Destroy(other.gameObject);      // 테스트한것 히트박스에 맞으면 죽음
            BoEnemyHealthManager eHealthManager;
            eHealthManager = other.gameObject.GetComponent<BoEnemyHealthManager>();
            eHealthManager.HurtEnemy(damageToGive);
        }
    }
}
