using UnityEngine;
using System.Collections;

public class TimerStep07 : MonoBehaviour 
{
	#region Inspector Variables
	public float playTime = 0f;
	public float stopTime = 0f;
	public float continueTime = 0f;

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
			playTime = Time.time - continueTime;
		}
		
		// Stops time.
		if( Input.GetKeyDown(KeyCode.Alpha3) )
		{
			stopTime = Time.time;
			timeActive = false;
		}
		
		// Continue time.
		if( Input.GetKeyDown(KeyCode.Alpha5) )
		{
			continueTime = Time.time - playTime;
			timeActive = true;
		}
	}
	
	void OnGUI()
	{
		GUILayout.Label("Time " + Time.time.ToString("f3"));
		GUILayout.Label("Play Time " + playTime.ToString("f3"));
		GUILayout.Label("Stop Time " + stopTime.ToString("f3"));
		GUILayout.Label("Continue Time " + continueTime.ToString("f3"));
		GUILayout.Label("Active " + timeActive.ToString());
	}
	#endregion Game Cycle
}
