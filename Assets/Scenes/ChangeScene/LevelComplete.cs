using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LoadSceneAsyncScene());
    }

    IEnumerator LoadSceneAsyncScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneAmount = SceneManager.sceneCountInBuildSettings;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync((currentSceneIndex + 1) % sceneAmount);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
