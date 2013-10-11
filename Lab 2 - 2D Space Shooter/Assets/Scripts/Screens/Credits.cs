using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour 
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
        GUI.BeginGroup(new Rect((Screen.width / 2 - 100), Screen.height / 2 - 100, 200, 200));

        // Show Credits to the User.
        GUI.Box(new Rect(0, 0, 200, 200), "Credits");

        // Instructions for the player.
        GUI.Label(new Rect(10, 40, 200, 50),  "Designer        Diogo Muller");
        GUI.Label(new Rect(10, 70, 200, 80),  "Artist             Diogo Muller");
        GUI.Label(new Rect(10, 100, 200, 110), "Programmer   Diogo Muller");
        GUI.Label(new Rect(10, 130, 200, 140), "Audio             Diogo Muller");

        // Back Button
        if( GUI.Button(new Rect(10, 160, 180, 30), "Back"))
        {
            Application.LoadLevel("MainMenu");
        }

        GUI.EndGroup();
    }
    #endregion Game Cycle Methods

    #region Methods
    #endregion Methods
}
