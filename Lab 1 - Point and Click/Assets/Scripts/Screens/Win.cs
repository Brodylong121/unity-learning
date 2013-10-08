using UnityEngine;
using System.Collections;

/// <summary>
/// Win screen GUI class.
/// </summary>
public class Win : MonoBehaviour 
{
	/// <summary>
	/// Event called on GUI drawing.
	/// </summary>
	void OnGUI()
	{
		GUI.Label(new Rect(10,10,100,40), "YOU WIN!");
		
		if( GUI.Button(new Rect(10, 50, 100, 50), "Restart Game") )
		{
			Application.LoadLevel("MainMenu");
		}
		if( GUI.Button(new Rect(10, 130, 100, 50), "Exit Game") )
		{
			Application.Quit();
		}
	}
}
