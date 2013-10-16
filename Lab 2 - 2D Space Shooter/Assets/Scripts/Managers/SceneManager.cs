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

    #region Level Type
    /// <summary>
    /// Level Label.
    /// </summary>
    public string levelLabel = "";

    /// <summary>
    /// Level Subtitle
    /// </summary>
    public string levelSubtitle = "";

    /// <summary>
    /// How much time label will be in the level.
    /// </summary>
    public float levelLabelTime = 3f;
    #endregion Level Type
    #endregion Inspector Variables

    #region Private Variables
    /// <summary>
    /// Level seconds remaining.
    /// </summary>
    private float seconds;

    /// <summary>
    /// Label seconds remaining.
    /// </summary>
    private float labelSeconds;
    #endregion Private Variables

    #region Styles
    private GUIStyle titleStyle;
    #endregion Styles

    #region Game Cycle Methods
    /// <summary>
    /// Initializes the Scene Manager.
    /// </summary>
    void Start()
    {
        seconds = gameTime;
        labelSeconds = levelLabelTime;

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

        if( labelSeconds > 0f)
        {
            labelSeconds -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Called to draw the GUI.
    /// </summary>
    void OnGUI()
    {
        #region Title Style
        if ( titleStyle == null )
        {            
            titleStyle = new GUIStyle(GUI.skin.label);

            titleStyle.alignment = TextAnchor.MiddleCenter;
            titleStyle.fontSize = 22;
            titleStyle.fontStyle = FontStyle.Bold;

        }
        #endregion Title Style

        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + score);
        GUI.Label(new Rect(10, 30, 100, 20), "Lives: " + lives);

        GUI.Label(new Rect(Screen.width - 70, 10, 60, 20), "Time: " + seconds);

        if( labelSeconds > 0f )
        {
            GUI.Label(new Rect(75, (Screen.height / 2 - 100), Screen.width - 150, 50), levelLabel, titleStyle);
            GUI.Label(new Rect(75, (Screen.height / 2 - 50), Screen.width - 150, 50), levelSubtitle, titleStyle);
        }
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
