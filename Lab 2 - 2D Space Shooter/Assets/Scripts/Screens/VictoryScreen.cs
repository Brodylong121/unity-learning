using UnityEngine;
using System.Collections;

public class VictoryScreen : MonoBehaviour 
{
    #region Inspector Variables
    #endregion Inspector Variables

    #region Private Variables
    #endregion Private Variables

    #region Game Cycle Methods
    /// <summary>
    /// Called to draw the GUI.
    /// </summary>
    void OnGUI()
    {
        // Make a group at the center of the screen.
        GUI.BeginGroup(new Rect((Screen.width / 2 - 100), Screen.height / 2 - 100, 200, 150));

        // Create a box to see the group on screen.
        GUI.Box(new Rect(0, 0, 200, 150), "You Win!");

        // Score.
        GUI.Label(new Rect(10, 30, 100, 30), "Score:      " + SceneManager.score);
        GUI.Label(new Rect(10, 60, 100, 30), "High Score: " + PlayerPrefs.GetInt("HighScore") );

        // Back Button
        if (GUI.Button(new Rect(10, 110, 180, 30), "Back to Main Menu"))
        {
            Application.LoadLevel("MainMenu");
        }

        GUI.EndGroup();
    }
    #endregion Game Cycle Methods

    #region Methods
    #endregion Methods
}
