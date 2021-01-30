using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateX : MonoBehaviour
{
    public GameObject cubeAxis;
    private void OnTriggerEnter(Collider other)
    {
        cubeAxis.GetComponent<spin>().rotateX(gameObject);
    }
}
