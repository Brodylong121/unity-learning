using UnityEngine;
using System.Collections;

public class TimerStep13 : MonoBehaviour 
{
	#region Inspector Variables
	public float playTime = 0f;
	
	public float days = 0f;
	public float hours = 0f;
	public float minutes = 0f;
	public float seconds = 0f;
	public float fractions = 0f;
	
	public bool timeActive = true;
	
	public float startTime = 0f;
	public float fromStartTime = 0f;
	public float fromLoadTime = 0f;
	
	public float stopTime = 0f;
	public float pauseGameTime = 0f;
	
	public float continueTime = 0f;
	
	public float countdownTime = 0.0f;
	public float countdownDelay = 0f;
	public float countdownAmount = 10f;
	public bool countdownActive = false;
	
	public float delayTime = 10f;
	public float delayedAmount = 0f;
	public int delaysCount = 0;
	
	public float addToTimeAmount = 0f;
	public float timeAmount = 0f;
	
	public float actualTime = 0f;
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
		// Calculates Play Time
		if( timeActive )
		{
			playTime = Time.time - continueTime + addToTimeAmount;;
		}
		
		// Calculates Countdown Time
		if( countdownActive )
		{
			countdownTime = countdownDelay - Time.time + countdownAmount;
		}
		
		days = ( playTime / 86400);
		hours = (playTime / 3600) % 24;
		minutes = (playTime / 60) % 60;
		seconds = (playTime % 60);
		fractions = (playTime * 1000 ) % 1000;
		
		// Start Time.		
		if( Input.GetKeyDown(KeyCode.Alpha1) )
		{
			startTime = Time.time;
		}
		
		// From Start Time
		fromStartTime = Time.time - startTime;
		
		// From Load Time.
		if( Input.GetKeyDown(KeyCode.Alpha2) )
		{
			fromLoadTime = Time.timeSinceLevelLoad;
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
		
		// Continue time.
		if( Input.GetKeyDown(KeyCode.Alpha5) )
		{
			continueTime = Time.time - playTime;
			timeActive = true;
		}
		
		// Reset time.
		if( Input.GetKeyDown(KeyCode.Alpha6) )
		{
			playTime = 0f;
			stopTime = 0f;
			timeActive = false;
		}
		
		// Countdown
		if( Input.GetKeyDown( KeyCode.Alpha7 ) )
		{
			countdownDelay = Time.time;
			countdownActive = true;
		}
		if( countdownTime < 0f )
		{
			countdownActive = false;
		}
		
		// Delay time.
		if( playTime > delayTime )
		{
			delayTime = playTime + delayedAmount;
			delaysCount++;
		}
		
		// Adds to timer a single amount, once.
		if( Input.GetKeyDown(KeyCode.Alpha8) )
		{
			addToTimeAmount = timeAmount;
		}
		
		// Adds to timer every time.
		if( Input.GetKeyDown(KeyCode.Alpha9) )
		{
			addToTimeAmount += timeAmount;
		}
		
		// Gets real time.
		if( Input.GetKeyDown(KeyCode.Alpha0) )
		{
			actualTime = Time.realtimeSinceStartup;
		}
	}
	
	void OnGUI()
	{
		GUILayout.Label("Play Time " + playTime);
		GUILayout.Label("Minutes " + minutes.ToString("f0"));
		GUILayout.Label("Seconds " + seconds.ToString("f0"));
		GUILayout.Label("Miliseconds " + fractions.ToString("f0"));
		
		GUILayout.Label("Start Time " + startTime.ToString("f3"));
		GUILayout.Label("From Start Time " + fromStartTime.ToString("f3"));
		
		GUILayout.Label("From Level Load " + fromLoadTime.ToString("f3"));
		
		GUILayout.Label("Stop Time " + stopTime.ToString("f3"));
		GUILayout.Label("Pause Time " + pauseGameTime.ToString("f3"));
		
		GUILayout.Label("Continue Time " + continueTime.ToString("f3"));
		
		GUILayout.Label("Countdown Time " + countdownTime.ToString("f3"));
		
		GUILayout.Label("Delay Time " + delayTime.ToString("f3"));
		GUILayout.Label("Delay Count " + delaysCount);
		
		GUILayout.Label("Actual Time " + actualTime.ToString("f3"));
		
		GUILayout.Label("Active " + timeActive.ToString());
		GUILayout.Label("Countdown Active " + countdownActive.ToString());
	}
	#endregion Game Cycle
}
