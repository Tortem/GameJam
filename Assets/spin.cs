using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public GameObject player;
    private bool rotate = false;
    public float rotationSpeed;
    float rotationCounter;

    // Start is called before the first frame update
    void Start()
    {

    }

    Vector3 rotation;

    public void rotateX(GameObject sphere)
    {

        if (rotate)
        {
            return;
        }
        gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        rotationCounter = 0;
        rotate = true;
        rotation = new Vector3(rotationSpeed, 0f, 0f);
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Cube"))
        {
            o.transform.SetParent(gameObject.transform);
        }

    }

    public void rotateY(GameObject sphere)
    {

        if (rotate)
        {
            return;
        }
        gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Cube"))
        {
            o.transform.SetParent(gameObject.transform);
        }
        
        rotationCounter = 0;
            rotate = true;
            rotation = new Vector3(0f, rotationSpeed, 0f);

    }

    public void rotateZ(GameObject sphere)
    {
        if (rotate)
        {
            return;
        }
        gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Cube"))
        {
            o.transform.SetParent(gameObject.transform);
        }
        rotationCounter = 0;
        rotate = true;
        rotation = new Vector3(0f, 0f, rotationSpeed);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotate && rotationCounter != 90)
        {
            gameObject.transform.Rotate(rotation);
            rotationCounter+= rotationSpeed;
        }
        else
        {
            if (rotate)
            {
                gameObject.transform.DetachChildren();
            }
            rotate = false;
        }
    }
}
