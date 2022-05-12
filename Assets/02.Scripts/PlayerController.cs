using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 게임 주 캐릭터 컨트롤러
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;
    private AudioSource playerAudio; // 플레이어 오디오 소스
    public AudioClip attackClip;     // 플레이어 공격 오디오
    public AudioClip walkClip;       // 플레이어 걷는 오디오
    public AudioClip getItem;        // 플레이어 아이템 습득 오디오

    [SerializeField]
    private float speed = 0;

    private float attackTime = 0.25f;
    private float attackCounter = 0.25f;
    private bool isAttacking;


    void Start()
    {
        playerAudio = GetComponent<AudioSource>(); // AudioSource Component 가져오기
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        //myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))/*.normalized*/ * speed * Time.deltaTime;     // 움직임 구현  normalized-대각선방향 움직일때 더 빨라지는것 막아줌

        myAnim.SetFloat("moveX", myRB.velocity.x);
        myAnim.SetFloat("moveY", myRB.velocity.y);          // 움직이는 애니메이션 구현
        

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            if (!playerAudio.isPlaying) // 플레이어 오디오가 실행되고 있지 않을 경우 if문 진입
            {
                playerAudio.Play();      // 플레이어 발소리
            }
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));         // 움직임이 멈췄을때의 방향 애니메이션 유지
        }

        if (isAttacking)
        {
            myRB.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                myAnim.SetBool("isAttacking", false);
                isAttacking = false;
                playerAudio.clip = walkClip; // 플레이어 오디오 걷기 모드로 전환
            }
        }

        if (Input.GetKeyDown(KeyCode.T))             // T키 누르면 공격
        {
            attackCounter = attackTime;
            myAnim.SetBool("isAttacking", true);
            isAttacking = true;

            playerAudio.clip = attackClip;            // 플레이어 공격 사운드
            if (playerAudio.isPlaying) return;        // 플레이어 오디오가 실행중이면 리턴
            else playerAudio.PlayOneShot(attackClip); // 플레이어 공격 사운드 한번 진행
        }
    }

    private void FixedUpdate()
    {
        myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))/*.normalized*/ * speed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.tag == "Item")
        {
            playerAudio.PlayOneShot(getItem); // 콜라이더 태그가 "Item"이면 아이템 습득 오디오 플레이 TAG 
            Debug.Log("[PlayerController.cs] Item Tag");
        }

        else if (other.tag == "Home")         // 콜라이더 태그 "Home"이면 "House" scene으로 이동
        {
            SceneManager.LoadScene("House");
        }
        
        else if (other.tag == "Main")         // 콜라이더 태그 "Main"이면 "Main"scene으로 이동
        {
            SceneManager.LoadScene("Main");
        }
    }

}
