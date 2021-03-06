﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spin : MonoBehaviour
{
    private bool rotate = false;
    public float rotationSpeed;
    float rotationCounter;

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


    void FixedUpdate()
    {
        if (Input.GetButton("Reload"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

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
