using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public GameObject obj;
    private bool s;
    int rotationCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!s)
            rotationCounter = 0;
        s = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (s && rotationCounter != 90)
        {
            obj.transform.Rotate(new Vector3(0f,0f,1f));
            rotationCounter++;
        }
        else
        {
            s = false;
        }
    }
}
