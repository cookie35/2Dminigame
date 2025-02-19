using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public GameObject flower;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(flower, transform.position, Quaternion.identity);
        }
    }
}
