using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    BoxCollider2D _boxCollider;
    public GameObject nametag;
    public GameObject txtWindow;  // 대사가 뜨는 창이미지

    [TextArea]
    public string[] txtNPC;  // NPC 대사 목록
    public Text mytext;
    public int textChecker = 0;
    bool textOn = false;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nametag.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (textOn == false)
                {
                    textOn = true;
                    txtNPC[textChecker] = mytext;
                    txtNPC[1]
                }
                //
                //textChecker++;
            }
        }
    }



}
