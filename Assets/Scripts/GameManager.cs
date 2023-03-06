using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Variables.
    [Header("Game")]
    public int score;
    public int highScore;
    public bool gameProgressing;

    [Header("Game Objects")]
    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreTextDisplay;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI highScoreTextDisplay;

    // Start is called before the first frame update.
    private void Start()
    {
        // Initialises game and gets previous high score (if there is one).
        score = 0;
        scoreTextDisplay.text = "Click";
        gameOverPanel.SetActive(false);

        // Disables pipe spawning.
        spawner.enabled = false;

        // Gets highscore.
        highScore = PlayerPrefs.GetInt("hi");
    }

    // EnablePipes will enable the pipe spawner.
    public void StartGame(Rigidbody2D playerRb)
    {
        // Enable pipe spawning.
        spawner.enabled = true;

        // Starts tallying score.
        scoreTextDisplay.text = score.ToString();

        // Sets player body type to dynamic, enables gravity & physics.
        playerRb.bodyType = RigidbodyType2D.Dynamic;
    }

    // GameOver will run when the player touches the pipe and the game is over.
    public void GameOver()
    {
        // Disables player movement.
        player.enabled = false;

        // Checks if the current score is greater than the current highscore.
        if(score > highScore)
        {
            // Updates high score and displays accordingly.
            PlayerPrefs.SetInt("hi", score);
            highScoreTextDisplay.text = "NEW HI: " + score.ToString();
        }
        else if(score <= highScore)
        {
            // If not, display previous high score.
            highScoreTextDisplay.text = "Hi: " + highScore.ToString();
        }

        // Enables the game over UI.
        gameOverPanel.SetActive(true);
        // Disables pipe spawning.
        spawner.enabled = false;
    }

    // Restart will restart the current scene.
    public void Restart()
    {
        // Restarts the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Interaction is called from the player and is often called for when colliding with a trigger or a collision.
    public void Interaction(GameObject obj)
    {
        // Checks what the colliding game object's tag it is.
        switch(obj.tag)
        {
            // If the game object's tag was "Pipe", the object is a physical pipe and the game over sequence should run.
            case "Pipe":
                GameOver();
                break;
            // If the game object's tag was score, it is a score trigger and should add score.
            case "Score":
                score++;
                scoreTextDisplay.text = score.ToString();
                break;
        }
    }
}
