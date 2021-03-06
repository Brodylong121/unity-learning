﻿using UnityEngine;
using System.Collections;

public class TimerStep14 : MonoBehaviour 
{
	#region Inspector Variables
	public float playTime = 0f;	
	public float days = 0f;
	public float hours = 0f;
	public float minutes = 0f;
	public float seconds = 0f;
	public float fractions = 0f;
		
	public float startTime = 0f;
	public float fromLoadTime = 0f;
	public float stopTime = 0f;
	public float continueTime = 0f;
	public float countdownDelay = 0f;
	public float countdownAmount = 0f;
	public float delayTime = 0f;
	public float delayRate = 0f;
	public float addToTime = 0f;
	public float addTimeAmount = 0f;
	public float realTime = 0f;
	
	public bool playTimeEnabled = false;
	public bool realTimeEnabled = false;
	public bool fromLoadTimeEnabled = false;
	public bool countdownEnabled = false;

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
		days = ( playTime / 86400);
		hours = (playTime / 3600) % 24;
		minutes = (playTime / 60) % 60;
		seconds = (playTime % 60);
		fractions = (playTime * 1000 ) % 1000;
		
		// Calculates Play Time
		if( playTimeEnabled && !countdownEnabled )
		{
			playTime = Time.time - startTime - continueTime + addToTime;
		}		
		
		// Start Time.		
		if( Input.GetKeyDown(KeyCode.Alpha1) )
		{
			startTime = Time.time;
			addToTime = 0f;
			continueTime = 0f;
			playTimeEnabled = true;
			countdownEnabled = false;
		}
		
		// From Load Time.
		if( Input.GetKeyDown(KeyCode.Alpha2) )
		{
			fromLoadTime = Time.timeSinceLevelLoad;
			startTime = 0f;
			addToTime = 0f;
			playTimeEnabled = false;
			realTimeEnabled = false;
			countdownEnabled = false;
			fromLoadTimeEnabled = true;
		}
		if( fromLoadTimeEnabled && !playTimeEnabled )
		{
			playTime = Time.timeSinceLevelLoad + addToTime;	
		}
		
		// Stops time.
		if( Input.GetKeyDown(KeyCode.Alpha3) )
		{
			stopTime = playTime;
			addToTime = 0;
			playTimeEnabled = false;
			realTimeEnabled = false;
			countdownEnabled = false;
			fromLoadTimeEnabled = false;
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
		
		// Continue time.
		if( Input.GetKeyDown(KeyCode.Alpha5) )
		{
			continueTime = Time.time - playTime;
			startTime = 0f;
			addToTime = 0f;
			playTimeEnabled = true;
			countdownEnabled = false;
		}
		
		// Reset time.
		if( Input.GetKeyDown(KeyCode.Alpha6) )
		{
			stopTime = 0f;
			playTime = 0f;
			continueTime = 0f;
			addToTime = 0f;
			realTimeEnabled = false;
			fromLoadTimeEnabled = false;
			countdownEnabled = false;
			playTimeEnabled = false;
		}
		
		// Countdown
		if( playTimeEnabled && countdownEnabled )
		{
			playTime = countdownDelay - Time.time + countdownAmount;
		}
		if( Input.GetKeyDown(KeyCode.Alpha7) )
		{
			countdownDelay = Time.time;
			playTimeEnabled = true;
			countdownEnabled = true;
			addToTime = 0;
		}
		if( playTime < 0 )
		{
			playTimeEnabled = false;
			countdownEnabled = false;
		}

		// Delay time.
		if( playTime > delayTime )
		{
			delayTime = playTime + delayRate;
		}
		
		// Adds to timer a single amount, once.
		if( Input.GetKeyDown(KeyCode.Alpha8) )
		{
			addToTime = addTimeAmount;
		}
		
		// Adds to timer every time.
		if( Input.GetKeyDown(KeyCode.Alpha9) )
		{
			addToTime += addTimeAmount;
		}
		
		// Gets real time.
		if( Input.GetKeyDown(KeyCode.Alpha0) )
		{
			realTime = Time.realtimeSinceStartup;
			startTime = 0f;
			addToTime = 0f;
			playTimeEnabled = false;
			realTimeEnabled = true;
			fromLoadTimeEnabled = false;
		}
		if( realTimeEnabled && !playTimeEnabled && !fromLoadTimeEnabled )
		{
			playTime = Time.realtimeSinceStartup + addToTime;
		}
	}
	
	void OnGUI()
	{
		GUILayout.Label("PlayTime " + playTime.ToString("f4") );
		GUILayout.Label("1 - Start the Time");
		GUILayout.Label("2 - From Load Time");
		GUILayout.Label("3 - Stop Time");
		GUILayout.Label("4 - Pause Game Time");
		GUILayout.Label("5 - Continue Time");
		GUILayout.Label("6 - Reset Time");
		GUILayout.Label("7 - Count Down Time");
		GUILayout.Label("8 - Add to Time Once");
		GUILayout.Label("9 - Add to Time Multi");
		GUILayout.Label("0 - Time Since Startup");
		
		GUILayout.Label("Minutes:     " + minutes.ToString("f0") );
		GUILayout.Label("Seconds:     " + seconds.ToString("f0") );
		GUILayout.Label("Miliseconds: " + fractions.ToString("f0") );
		
		GUILayout.Label("Delay Time " + delayTime.ToString("f4") );
		GUILayout.Label("Continue Time " + continueTime.ToString("f4") );
		
	}
	#endregion Game Cycle
}
