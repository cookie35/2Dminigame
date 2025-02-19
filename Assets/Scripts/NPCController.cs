using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NPCController : MonoBehaviour
{
    Animator animator;

    public GameObject txtWindow;  // 대사가 뜨는 창이미지
    [TextArea]
    public string[] txtNPC;  // NPC 대사 목록
    public Text myText;  // 변화될 대화문들이 입력될 곳
    public int textNumber = 0; // 어떤 텍스트인지 체크해주는 변수
    bool textOn = false;  // 텍스트 기능을 킬건지 여부
    bool isTalking = false;  // 대화 중인지 여부

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        myText.text = txtNPC[0];
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)  // 충돌했을 때 1번만 작동
    {
        if (collision.CompareTag("Player"))
        {
            txtWindow.SetActive(true);
            animator.SetBool("Selected", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  // 충돌에서 나갈 때 1번만 작동
    {
        if (collision.CompareTag("Player"))
        {
            txtWindow.SetActive(false);
            animator.SetBool("Selected", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)  // 충돌해서 머무르는 동안 계속
    {
        if (collision.CompareTag("Player") && !isTalking && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("f누름");
            isTalking = true;  // 대화 시작 (다시 입력 방지)
            StartCoroutine(ShowDialogue()); // 대화 시작
        }
    }

    private IEnumerator ShowDialogue()   // IEumerator는 순차적으로 재생해주는 재생기 역할
    {
        textOn = true;

        while (textNumber < txtNPC.Length)
        {   
            
            myText.text = txtNPC[textNumber];  // 현재 텍스트 표시
            textNumber++; // 다음 텍스트로 이동

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));  // F키를 누를 때까지 대기

        }

        Debug.Log("대화 종료!");
        textOn = false;
        isTalking = false;  // 대화 끝나면 다시 대화 가능하게 변경

    }
    
}
