using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    private bool stopAddScore = false;
    private static int topScore;
    public Text topScoreText;

    private void Start()
    {
        // 1. Načítame uložené top skóre z disku pod kľúčom "TopScore"
        topScore = PlayerPrefs.GetInt("TopScore", 0);

        // 2. Zobrazíme načítané top skóre na obrazovke
        topScoreText.text = "Top Score: " + topScore.ToString();
        scoreText.text = playerScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (stopAddScore == false)
        {
            playerScore = playerScore + scoreToAdd;
            if (playerScore > topScore)
            {
                topScore = playerScore;
                PlayerPrefs.SetInt("TopScore", topScore);
                PlayerPrefs.Save(); // Zapíše dáta na disk
            }
        }
        
        topScore = PlayerPrefs.GetInt("TopScore", 0); // 0 je predvolená hodnota, ak kľúč neexistuje
        scoreText.text = playerScore.ToString();
        topScoreText.text = "Top Score: " + topScore.ToString();


    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        stopAddScore = true;
    }
}
