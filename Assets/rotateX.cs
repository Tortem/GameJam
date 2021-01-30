using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateX : MonoBehaviour
{
    private GameObject cubeAxis;

    private void Awake()
    {
        cubeAxis = GameObject.FindGameObjectWithTag("Axis");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("shit");
        cubeAxis.GetComponent<spin>().rotateX(gameObject);
    }
}
