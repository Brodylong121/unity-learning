using UnityEngine;
using System.Collections;

/// <summary>
/// Main menu script.
/// </summary>
public class MainMenu : MonoBehaviour 
{
	/// <summary>
	/// Event called on GUI drawing.
	/// </summary>
	void OnGUI()
	{
		if( GUI.Button(new Rect(10, 10, 90, 50), "Start Game") )
		{
			Application.LoadLevel("Level");
		}
		if( GUI.Button(new Rect(10, 70, 90, 50), "Exit Game") )
		{
			Application.Quit();
		}
	}
}
