using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private static bool isPaused = false;

    public static bool IsPaused { get { return isPaused; } }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Button();
        }
    }
    private void Button()
    {
        if (IsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        //Time.timeScale = 1f;
    }
}