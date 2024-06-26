using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelGameLoader : MonoBehaviour
{
    public GameObject LoadScreen;
    public Slider slider;
    public float fakeLoadDuration = 3f;

    public void LoadLevel(string scene)
    {
        StartCoroutine(FakeLoad(scene));
    }
    IEnumerator FakeLoad(string sceneName)
    {
        slider.value = 0;
        LoadScreen.SetActive(true);

        float elapsedTime = 0;

        while (elapsedTime < fakeLoadDuration)
        {
            elapsedTime += Time.deltaTime;
            slider.value = Mathf.Clamp01(elapsedTime / fakeLoadDuration);
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}
