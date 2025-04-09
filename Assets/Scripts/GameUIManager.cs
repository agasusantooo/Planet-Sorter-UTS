using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    // Fungsi untuk restart level (ulang game)
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Fungsi untuk kembali ke Main Menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Pastikan nama scene Main Menu benar
    }

    // Fungsi untuk keluar dari aplikasi (opsional)
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // Hanya muncul saat di editor
    }
}
