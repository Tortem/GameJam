using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateZ : MonoBehaviour
{
    public GameObject cubeAxis;
    private void OnTriggerEnter(Collider other)
    {
        cubeAxis.GetComponent<spin>().rotateZ(gameObject);
    }
}
