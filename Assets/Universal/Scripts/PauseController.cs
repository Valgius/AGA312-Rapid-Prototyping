using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pausePanel;
    private bool paused;

    private void Start()
    {
        paused = false;
        pausePanel.SetActive(paused);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Pause()
    {
        paused = !paused;
        pausePanel.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }
}
