using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
    #region Static Variables
    /// <summary>
    /// Player score.
    /// </summary>
    public static int score = 0;

    /// <summary>
    /// The player lives.
    /// </summary>
    public static int lives = 3;
    #endregion Static Variables

    #region Inspector Variables
    /// <summary>
    /// Game time.
    /// </summary>
    public float gameTime = 60f;
    #endregion Inspector Variables

    #region Private Variables
    /// <summary>
    /// Level seconds remaining.
    /// </summary>
    private float seconds;
    #endregion Private Variables

    #region Game Cycle Methods
    /// <summary>
    /// Initializes the Scene Manager.
    /// </summary>
    void Start()
    {
        seconds = gameTime;

        InvokeRepeating("Countdown", 1f, 1f);
    }
    
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Updates High Score, if needed.
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        // If you lose all your lives, you lose the game.
        if( lives <= 0 )
        {
            Application.LoadLevel("GameOver");
        }

        // If the time ends, you win!
        if( seconds <= 0 )
        {
            Application.LoadLevel("VictoryScreen");
        }
    }

    /// <summary>
    /// Called to draw the GUI.
    /// </summary>
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + score);
        GUI.Label(new Rect(10, 30, 100, 20), "Lives: " + lives);

        GUI.Label(new Rect(Screen.width - 70, 10, 60, 20), "Time: " + seconds);
    }
    #endregion Game Cycle Methods

    #region Methods
    /// <summary>
    /// Adds score.
    /// </summary>
    /// <param name="value">Amount to be added.</param>
    public static void AddScore(int value = 1)
    {
        score += value;
    }

    /// <summary>
    /// Substracts one or more lives from the player
    /// </summary>
    /// <param name="value">Number of lives to be subtracted.</param>
    public static void SubtractLives(int value = 1)
    {
        lives -= value;
    }

    /// <summary>
    /// Decrements the counter and stops when < 0.
    /// </summary>
    void Countdown()
    {
        if( --seconds == 0 )
        {
            CancelInvoke("Countdown");
        }
    }
    #endregion Methods
}
