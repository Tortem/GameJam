using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateZ : MonoBehaviour
{
    private GameObject cubeAxis;

    private void Awake()
    {
        cubeAxis = GameObject.FindGameObjectWithTag("Axis");
    }

    private void OnTriggerEnter(Collider other)
    {
        cubeAxis.GetComponent<spin>().rotateZ(gameObject);
    }
}
