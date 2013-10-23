using UnityEngine;
using System.Collections;

public class TimerStep06 : MonoBehaviour 
{
	#region Inspector Variables
	public float playTime = 0f;
	public float stopTime = 0f;
	public float pauseGameTime = 0f;
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
		
		// Stops time.
		if( Input.GetKeyDown(KeyCode.Alpha3) )
		{
			stopTime = Time.time;
			timeActive = false;
		}
		
		// Time scale.
		if( Input.GetKeyDown(KeyCode.Alpha4) )
		{
			Time.timeScale = 0.0f;
			pauseGameTime = Time.time;
		}
		else if( Input.GetKeyUp(KeyCode.Alpha4) )
		{
			Time.timeScale = 1.0f;
		}
	}
	
	void OnGUI()
	{
		GUILayout.Label("Play Time " + playTime.ToString("f3"));
		GUILayout.Label("Stop Time " + stopTime.ToString("f3"));
		GUILayout.Label("Pause Time " + pauseGameTime.ToString("f3"));
		GUILayout.Label("Active " + timeActive.ToString());
	}
	#endregion Game Cycle
}
