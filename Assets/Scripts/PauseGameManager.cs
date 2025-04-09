using UnityEngine;
using TMPro;

public class PauseGameManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseTextUI; // Drag UI PAUSED text ke sini di Inspector

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            if (pauseTextUI != null)
                pauseTextUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            if (pauseTextUI != null)
                pauseTextUI.SetActive(false);
        }
    }
}
