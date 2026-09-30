using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource scoreSound;
    public bool isAlive = true;

    public Text highScoreText;
    public Text finalScoreText;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        scoreSound.Play();
    }

    int highScore = PlayerPrefs.GetInt("SavedHighScore", 0);

    public void HighScore()
    {
        //Is there already a highscore?
 

        if (PlayerPrefs.HasKey("SavedHIghScore"))
        {
            //is the new score higher than the saved one?
            if (playerScore > PlayerPrefs.GetInt("SavedHighScore", 0))
            {
                //Set a new high score
                PlayerPrefs.SetInt("SavedHighScore", playerScore);
            }
        }

        else
        {
            //if there is no high score... set it
            PlayerPrefs.SetInt("SavedHighScore", playerScore);
        }

        //Update our TMP
        finalScoreText.text = "High Score: " + playerScore.ToString();
        highScoreText.text = PlayerPrefs.GetInt("SavedHighScore", 0).ToString();
    }


    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        isAlive = false;
        gameOverScreen.SetActive(true);

        //Call the HighScoreUpdate function
        HighScore();
    }
}
