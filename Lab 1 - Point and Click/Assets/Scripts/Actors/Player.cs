using UnityEngine;
using System.Collections;

/// <summary>
/// Player script.
/// </summary>
public class Player : MonoBehaviour 
{	
	#region Inspector Variables
	/// <summary>
	/// Allows the designer to set a tag in the inspector.
	/// </summary>
	public string tagName;
	
	/// <summary>
	/// The lenght of the ray for a raycast.
	/// </summary>
	public float rayDistance = 10f;
	
	/// <summary>
	/// Score for our player.
	/// </summary>
	public int score = 0;
	
	/// <summary>
	/// Amount of time the game will last.
	/// </summary>
	public float gameTime = 20f;
	
	/// <summary>
	/// Amount of time before we load the next level.
	/// </summary>
	public float loadWaitTime = 1.0f;
	
	/// <summary>
	/// The points needed to win.
	/// </summary>
	public int pointsToWin = 20;
	#endregion Inspector Variables
	
	#region Private Variables
	#endregion Private Variables
	
	#region Game Cycle Methods
	/// <summary>
	/// Initializes this instance.
	/// </summary>
	void Start ()
	{
		InvokeRepeating("CountDown", 1.0f, 1.0f);
	}
	
	/// <summary>
	/// Update is called every frame.
	/// </summary>
	void Update () 
	{
		// Use the mouse button to select Game Objects in the scene.
		if( Input.GetMouseButtonDown(0) )
		{
			//Raycast hit information.
			RaycastHit hit;
			
			//Get mouse position.
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			// Cast a ray against all colliders in the scene.
			if( Physics.Raycast(ray, out hit, rayDistance) )
			{
				if( hit.transform.tag == tagName )
				{
					Enemy enemy = (Enemy) hit.transform.GetComponent("Enemy");
					enemy.numberOfClicks--;
					
					// Enemy was destroyed.
					if( enemy.numberOfClicks == 0 )
					{
						// Add points to the overall score
						score += enemy.enemyPoints;
					}
				}
			}
		}
	}
	
	/// <summary>
	/// Draws the level GUI.
	/// </summary>
	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 20), "Score: " + score);
		GUI.Label(new Rect(10, 25, 100, 35), "Time:  " + gameTime);
	}
	#endregion Game Cycle Methods
	
	#region Methods
	/// <summary>
	/// Updates game counter.
	/// </summary>
	void CountDown()
	{
		//Subtract from the Game Time.
		if( --gameTime <= 0f )
		{
			//Cancel the Countdown.
			CancelInvoke("CountDown");
			
			if( score >= pointsToWin )
			{
				Application.LoadLevel("Win");
			}
			else
			{
				Application.LoadLevel("Lose");
			}
		}
	}
	#endregion Methods
}
