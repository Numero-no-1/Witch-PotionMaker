using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 물약상점 애니메이션 컨트롤러
public class LaboratoryController : MonoBehaviour
{
    public Animator labInvenAnim; // 마지막 애니메이터 변수

    public Animator animator;     // 버튼 애니메이터 실행
    public GameObject labPanel;   // 애니매이션일 실행될 게임 오브젝트

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator의 Component 가져옴

    }

    // OK버튼을 눌렀을 때, 애니매이션 실행
    public void OkButton()
    {
        Debug.Log("On Ok Button!");
        animator.SetBool("OkBtn", true);     // 애니메이션 실행 조건
        labInvenAnim.SetTrigger("OKbutton"); ; // 실행할 애니메이션
    }

    //craft버튼을 눌렀을 때, 애니매이션 실행
    public void OnCraftButton()
    {
        Debug.Log("On Craft Button!");
        animator.SetBool("CraftBtn", true); // 애니메이션 실행 조건
        labInvenAnim.SetTrigger("LAB01");   // 실행할 애니메이션
    }


    // 마지막 인벤토리 창 띄우기
    public void EndIven()
    {
        labInvenAnim.SetTrigger("End"); // 이벤트 조건 실행시 "End" 애니메이션 진행
    }
}
