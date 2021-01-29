using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float rotaionSpeed;
    public GameObject obj;
    private bool s;
    float rotationCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!s)
                rotationCounter = 0;
            s = true;
        }

        if (s && rotationCounter != 90/rotaionSpeed)
        {
            obj.transform.Rotate(new Vector3(0f, 0f, -rotaionSpeed));
            rotationCounter += rotaionSpeed;
        }
        else
        {
            s = false;
        }
    }
}
