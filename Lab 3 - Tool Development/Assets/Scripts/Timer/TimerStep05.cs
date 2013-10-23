using UnityEngine;
using System.Collections;

public class TimerStep05 : MonoBehaviour 
{
	#region Inspector Variables
	public float playTime = 0f;
	public float startTime = 0f;
	public float fromStartTime = 0f;
	public float fromLoadTime = 0f;
	
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
		
		// Sets start time.
		if( Input.GetKeyDown(KeyCode.Alpha1) )
		{
			startTime = Time.time;
		}
		
		// Gets time from level load.
		if( Input.GetKeyDown(KeyCode.Alpha2) )
		{
			fromLoadTime = Time.timeSinceLevelLoad;
		}
		
		fromStartTime = Time.time - startTime;
	}
	
	void OnGUI()
	{
		GUILayout.Label("Play Time " + playTime.ToString("f3"));
		GUILayout.Label("Start Time " + startTime.ToString("f3"));
		GUILayout.Label("From Start Time " + fromStartTime.ToString("f3"));
		GUILayout.Label("From Level Load " + fromLoadTime.ToString("f3"));
		GUILayout.Label("Active " + timeActive.ToString());
	}
	#endregion Game Cycle
}
