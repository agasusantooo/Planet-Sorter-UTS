using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int currentScore = 0;
    public int lives = 3;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
        gameOverPanel.SetActive(false); // Sembunyikan UI Game Over saat start
        Time.timeScale = 1f; // Pastikan game berjalan normal
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateUI();
    }

    public void ReduceScore(int amount)
    {
        currentScore -= amount;
        if (currentScore < 0) currentScore = 0;
        UpdateUI();
    }

    public void LoseLife()
    {
        lives--;
        if (lives < 0) lives = 0;

        UpdateUI();

        if (lives == 0)
        {
            ShowGameOver();
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }

        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }

    void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (finalScoreText != null)
        {
            finalScoreText.text = "Your Score: " + currentScore;
        }

        if (highScoreText != null)
        {
            int highscore = PlayerPrefs.GetInt("HighScore", 0);
            if (currentScore > highscore)
            {
                PlayerPrefs.SetInt("HighScore", currentScore);
                highscore = currentScore;
            }
            highScoreText.text = "High Score: " + highscore;
        }

        // Stop game saat Game Over
        Time.timeScale = 0f;
    }

    // Dipanggil dari tombol Restart
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Dipanggil dari tombol Exit/Main Menu
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
