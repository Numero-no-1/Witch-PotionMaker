using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������� �ִϸ��̼� ��Ʈ�ѷ�
public class LaboratoryController : MonoBehaviour
{
    public Animator labInvenAnim; // ������ �ִϸ����� ����

    public Animator animator;     // ��ư �ִϸ����� ����
    public GameObject labPanel;   // �ִϸ��̼��� ����� ���� ������Ʈ

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator�� Component ������

    }

    // OK��ư�� ������ ��, �ִϸ��̼� ����
    public void OkButton()
    {
        Debug.Log("On Ok Button!");
        animator.SetBool("OkBtn", true);     // �ִϸ��̼� ���� ����
        labInvenAnim.SetTrigger("OKbutton"); ; // ������ �ִϸ��̼�
    }

    //craft��ư�� ������ ��, �ִϸ��̼� ����
    public void OnCraftButton()
    {
        Debug.Log("On Craft Button!");
        animator.SetBool("CraftBtn", true); // �ִϸ��̼� ���� ����
        labInvenAnim.SetTrigger("LAB01");   // ������ �ִϸ��̼�
    }


    // ������ �κ��丮 â ����
    public void EndIven()
    {
        labInvenAnim.SetTrigger("End"); // �̺�Ʈ ���� ����� "End" �ִϸ��̼� ����
    }
}
