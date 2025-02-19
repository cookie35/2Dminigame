using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))  // enemy tag�� �޷ȴ��� üũ�ϰ� gameObject�� �����Ͷ�.
        {
            Destroy(collision.gameObject);  // �ε��� ���� ������Ʈ�� �ν���.
        }
    }

}
