using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour  // 방벽에 부딪히면 게임화면을 넘어서 간 enemy 오브젝트를 없애줍니다.
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))  // enemy tag가 달렸는지 체크하고 gameObject를 가져와라.
        {
            Destroy(collision.gameObject);  // 부딪힌 게임 오브젝트를 부숴라.
        }
    }

}
