using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelGameLoader : MonoBehaviour
{
    public GameObject LoadScreen;
    public Slider slider;
    public void LoadLevel(string scene)
    {
        StartCoroutine(LoadAsynchronously(scene));
    }

    IEnumerator LoadAsynchronously(string sceneIndex)
    {
        slider.value = 0;
        LoadScreen.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        asyncOperation.allowSceneActivation = false;

        float progress = 0;

        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            slider.value = progress;

            if(progress >= 0.9f)
            {
                slider.value = 1f;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}