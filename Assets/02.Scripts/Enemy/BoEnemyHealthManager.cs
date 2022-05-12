using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 보스 해골
public class BoEnemyHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    //public GameObject itemPrefab;

    private AudioSource bossAudio; // 보스 해골 오디오 소스
    public AudioClip bossOver;      // 보스 꽥 오디오

    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;

    void Start()
    {
        bossAudio = GetComponent<AudioSource>(); // AudioSource Component 가져오기
        enemySprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (flashActive)        // 데미지 입을때마다 깜빡거리는 효과 줌
        {
            if (flashCounter > flashLength * .99f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }

            else
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    //public void DropItem()
    //{
    //    var itemGo = Instantiate<GameObject>(this.itemPrefab);
    //    itemGo.transform.position = this.gameObject.transform.position;
    //    itemGo.SetActive(false);
    //    if (currentHealth == 0)
    //    {
    //        itemGo.SetActive(true);
    //    }
    //}


    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;

        if (currentHealth <= 0)
        {
            bossAudio.PlayOneShot(bossOver);// 보스 해골 꽥

            //this.DropItem();
            new WaitForSeconds(2f);
            Destroy(gameObject);
            SceneManager.LoadScene("PotionShop");
        }
    }
}
