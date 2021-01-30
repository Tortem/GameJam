using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SetLevelName : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = SceneManager.GetActiveScene().name;
    }
}
