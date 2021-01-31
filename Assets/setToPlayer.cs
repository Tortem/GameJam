using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setToPlayer : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        gameObject.transform.position = player.transform.position + new Vector3(2f,0f,0f);
    }
}
