using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private static bool isPaused = false;

    public static bool IsPaused { get { return isPaused; } set { isPaused = value; } }

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
        Time.timeScale = 0f;
        IsPaused = true;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        pauseMenu.SetActive(false);
    }
}