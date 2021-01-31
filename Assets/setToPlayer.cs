using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setToPlayer : MonoBehaviour
{
    GameObject player;
    private int switchCounter = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        gameObject.transform.position = player.transform.position + new Vector3(2f,0f,0f);

        if (Input.GetButton("Donut") && switchCounter <= 0)
        {
            switchCounter = 60;
            for (int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(!transform.GetChild(i).gameObject.activeSelf);
            }
        }
        switchCounter--;
    }
}
