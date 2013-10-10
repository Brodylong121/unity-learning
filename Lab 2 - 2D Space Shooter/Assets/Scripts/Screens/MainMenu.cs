using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
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
        GUI.BeginGroup(new Rect((Screen.width / 2 - 50), Screen.height / 2 - 50, 100, 175));

        // Create a box to see the group on screen.
        GUI.Box(new Rect(0, 0, 100, 175), "Main Menu");

        // Add buttons for navigation.
        if( GUI.Button(new Rect(10, 30, 80, 30), "Start Game") )
        {
            Application.LoadLevel("LoadingScreen");
        }

        // Add buttons for navigation.
        if (GUI.Button(new Rect(10, 65, 80, 30), "Credits"))
        {
            Application.LoadLevel("Credits");
        }
        // Add buttons for navigation.
        if (GUI.Button(new Rect(10, 100, 80, 30), "Homepage"))
        {
            Application.OpenURL("http://www.diogomuller.com.br");
        }
        // Add buttons for navigation.
        if (GUI.Button(new Rect(10, 135, 80, 30), "Exit Game"))
        {
            Application.Quit();
        }

        GUI.EndGroup();
    }
    #endregion Game Cycle Methods

    #region Methods
    #endregion Methods
}
