using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour 
{
    #region Inspector Variables
    public float waitTime = 3f;
    #endregion Inspector Variables

    #region Private Variables
    #endregion Private Variables

    #region Game Cycle Methods

    /// <summary>
    /// Update is called once every frame.
    /// </summary>
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("Level01"); // Start Game
        }
        else
        {
            StartCoroutine(WaitTime());
        }
    }

    /// <summary>
    /// Called to draw the GUI.
    /// </summary>
    void OnGUI()
    {
        // Make a group at the center of the screen.
        GUI.BeginGroup(new Rect((Screen.width / 2 - 100), Screen.height / 2 - 100, 200, 200));

        // Create a box to see the group on screen.
        GUI.Box(new Rect(0, 0, 200, 200), "Instructions");

        // Instructions for the player.
        GUI.Label( new Rect(10, 30, 140, 40), "Arrow Keys / WASD to Move" );
        GUI.Label( new Rect(10, 60, 160, 70), "Spacebar to Shoot" );
        GUI.Label( new Rect(10, 90, 160, 100), "Escape to Quit" );

        //Ends group started on BeginGroup.
        GUI.EndGroup();
    }
    #endregion Game Cycle Methods

    #region Methods
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime);
        Application.LoadLevel("Level01");
    }
    #endregion Methods
}
