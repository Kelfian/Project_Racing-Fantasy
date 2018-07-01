using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Loading : MonoBehaviour
{
    private Transform loadingScreen;
    //private Animator blackScreen;
    private TextMeshProUGUI loadingText;

    private void Start()
    {
        loadingScreen = transform.GetChild(5);
        //blackScreen = loadingScreen.GetComponent<Animator>();
        loadingText = loadingScreen.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void LoadScene(int i)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadingScene(i));
    }
    IEnumerator LoadingScene(int i)
    {
        AsyncOperation progress = SceneManager.LoadSceneAsync(i);
        progress.allowSceneActivation = false;
        loadingScreen.gameObject.SetActive(true);
        //blackScreen.SetTrigger("");
        if (progress.progress >= 0.9f)
        {
            progress.allowSceneActivation = true;
        }
        else
        {
            loadingText.text = progress.progress.ToString() + "%";
        }
        yield return null;
    }
}
