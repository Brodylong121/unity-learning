using UnityEngine;
using System.Collections;

public enum TimerType
{
	Playtime,
	Realtime,
	FromLoad,
	Countdown,
	Inactive
}

public class Timer : MonoBehaviour
{
	#region Inspector Variables
	public float playTime = 0f;	
	public float days = 0f;
	public float hours = 0f;
	public float minutes = 0f;
	public float seconds = 0f;
	public float fractions = 0f;
	#endregion Inspector Variables
	
	#region Private Variables
	private float startTime = 0f;
	private float fromLoadTime = 0f;
	private float stopTime = 0f;
	private float continueTime = 0f;
	private float countdownDelay = 0f;
	private float countdownAmount = 0f;
	private float delayTime = 0f;
	private float delayRate = 0f;
	private float addToTime = 0f;
	private float addTimeAmount = 0f;
	private float realTime = 0f;
	
	private TimerType currentTimer = TimerType.Inactive;
	#endregion Private Variables
	
	#region Cycle Methods
	void Update()
	{
		days = ( playTime / 86400);
		hours = (playTime / 3600) % 24;
		minutes = (playTime / 60) % 60;
		seconds = (playTime % 60);
		fractions = (playTime * 1000 ) % 1000;
		
		switch( currentTimer )
		{
			case playTime:
				playTime = Time.time - startTime - continueTime + addToTime;
				break;
			case TimerType.FromLoad:
				playTime = Time.timeSinceLevelLoad + addToTime;
				break;
			case TimerType.Countdown:
				playTime = countdownDelay - Time.time + countdownAmount;
				break;
			case TimerType.Realtime:
				playTime = Time.realtimeSinceStartup + addToTime;
				break;
			default:
				playTime = 0f;
		}
	}
	#endregion Cycle Methods
}
