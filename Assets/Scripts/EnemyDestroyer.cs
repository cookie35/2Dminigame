using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))  // enemy tag가 달렸는지 체크하고 gameObject를 가져와라.
        {
            Destroy(collision.gameObject);  // 부딪힌 게임 오브젝트를 부숴라.
        }
    }

}
