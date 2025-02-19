using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.005f;

    private void FixedUpdate()
    {
        transform.position += Vector3.left * speed;
    }

}
