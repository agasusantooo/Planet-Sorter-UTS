using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay"); // Ganti dengan nama scene utama kamu
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Keluar dari game."); // Tidak akan terlihat di build WebGL
    }
}
