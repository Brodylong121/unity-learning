using UnityEngine;
using System.Collections;

public class TimerStep12 : MonoBehaviour 
{
	#region Inspector Variables
	public float playTime = 0f;
	public float actualTime = 0f;

	public bool timeActive = true;
	#endregion Inspector Variables
	
	#region Game Cycle
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () 
	{
	
	}
	
	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update () 
	{
		// Is the time active?
		if( timeActive )
		{
			playTime = Time.time;
		}
		
		// Gets real time.
		if( Input.GetKeyDown(KeyCode.Alpha0) )
		{
			actualTime = Time.realtimeSinceStartup;
		}
		
		// Time scale.
		if( Input.GetKeyDown(KeyCode.Alpha4) )
		{
			Time.timeScale = 0.0f;
		}
		else if( Input.GetKeyUp(KeyCode.Alpha4) )
		{
			Time.timeScale = 1.0f;
		}
	}
	
	void OnGUI()
	{
		GUILayout.Label("Play Time " + playTime.ToString("f3"));
		GUILayout.Label("Actual Time " + actualTime.ToString("f3"));
	}
	#endregion Game Cycle
}