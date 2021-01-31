using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadSceneAsyncScene());
        }
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

    void Update()
    {
        float cos = Mathf.Cos(Time.time);
        float scale = 1 + cos * .25f;
        transform.localScale = new Vector3(scale, scale, scale);
        transform.Rotate(0f, 50 * Time.deltaTime, 0f);

    }
}
