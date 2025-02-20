using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class NPCController : MonoBehaviour
{
    Animator animator;

    public GameObject txtWindow;  // ��簡 �ߴ� â�̹���
    [TextArea]
    public string[] txtNPC;  // NPC ��� ���
    public Text myText;  // ��ȭ�� ��ȭ������ �Էµ� ��
    public int textNumber = 0; // � �ؽ�Ʈ���� üũ���ִ� ����
    public bool isSceneChanger = true;  // on/off ����ġ. y�� ������ ���� �ٲ��ִ� �汸������� üũ�ϼ���. �ƴϸ� üũ�����ϼ���
    bool isTalking = false;  // ��ȭ ������ ����

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        myText.text = txtNPC[0];
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)  // �浹���� �� 1���� �۵�
    {
        if (collision.CompareTag("Player"))
        {
            txtWindow.SetActive(true);
            animator.SetBool("Selected", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  // �浹���� ���� �� 1���� �۵�
    {
        if (collision.CompareTag("Player"))
        {
            txtWindow.SetActive(false);
            animator.SetBool("Selected", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)  // �浹�ؼ� �ӹ����� ���� ���
    {
        if (collision.CompareTag("Player"))
        {
            if (!isTalking && Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("f����");
                isTalking = true;  // ��ȭ ���� (�ٽ� �Է� ����)
                StartCoroutine(ShowDialogue()); // ��ȭ ����
            }
        }
    }

    private IEnumerator ShowDialogue()   // IEumerator�� ���������� ������ִ� ����� ����
    {
        

        while (textNumber < txtNPC.Length)
        {               
            myText.text = txtNPC[textNumber];  // ���� �ؽ�Ʈ ǥ��
            textNumber++; // ���� �ؽ�Ʈ�� �̵�
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));  // FŰ�� ���� ������ ���
            // ���� ������ �ȿ��� ó���� �Ǵٺ��� �������� �����־���... 
            yield return new WaitForFixedUpdate(); // �� ����� �ð��� ��ٸ�����
        }

        if (isSceneChanger) 
        { 
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.N));

            if (Input.GetKeyDown(KeyCode.Y)) SceneManager.LoadScene("Game");  // ���� ������ �̵�
            else Debug.Log("���� ȭ������ �̵�");  // �ڷ� ���� ���� (�ʿ��ϸ� �߰�)
        }

        isTalking = false;  // ��ȭ ������ �ٽ� ��ȭ �����ϰ� ����

    }
    
}
