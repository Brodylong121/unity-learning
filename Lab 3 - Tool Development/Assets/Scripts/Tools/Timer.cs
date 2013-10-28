using UnityEngine;
using System.Collections;

/// <summary>
/// Timer type.
/// </summary>
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
	/// <summary>
	/// The play time.
	/// </summary>
	public float playTime = 0f;	
	/// <summary>
	/// The days.
	/// </summary>
	public float days = 0f;
	/// <summary>
	/// The hours.
	/// </summary>
	public float hours = 0f;
	/// <summary>
	/// The minutes.
	/// </summary>
	public float minutes = 0f;
	/// <summary>
	/// The seconds.
	/// </summary>
	public float seconds = 0f;
	/// <summary>
	/// The fractions.
	/// </summary>
	public float fractions = 0f;
	/// <summary>
	/// The delay rate.
	/// </summary>
	public float delayRate = 0f;
	#endregion Inspector Variables
	
	#region protected Variables
	/// <summary>
	/// The start time.
	/// </summary>
	protected float startTime = 0f;
	/// <summary>
	/// From load time.
	/// </summary>
	protected float fromLoadTime = 0f;
	/// <summary>
	/// The stop time.
	/// </summary>
	protected float stopTime = 0f;
	/// <summary>
	/// The continue time.
	/// </summary>
	protected float continueTime = 0f;
	/// <summary>
	/// The countdown delay.
	/// </summary>
	protected float countdownDelay = 0f;
	/// <summary>
	/// The countdown amount.
	/// </summary>
	protected float countdownAmount = 0f;
	/// <summary>
	/// The delay time.
	/// </summary>
	protected float delayTime = 0f;
	/// <summary>
	/// Extra time added to time.
	/// </summary>
	protected float addToTime = 0f;
	/// <summary>
	/// The real time.
	/// </summary>
	protected float realTime = 0f;
	
	protected TimerType currentTimer = TimerType.Inactive;
	#endregion protected Variables
	
	#region Cycle Methods
	/// <summary>
	/// Update this instance.
	/// </summary>
	public virtual void Update()
	{
		days = ( playTime / 86400);
		hours = (playTime / 3600) % 24;
		minutes = (playTime / 60) % 60;
		seconds = (playTime % 60);
		fractions = (playTime * 1000 ) % 1000;
		
		switch( currentTimer )
		{
			case TimerType.Playtime:
				playTime = Time.time - startTime - continueTime + addToTime;
				break;
			case TimerType.FromLoad:
				playTime = Time.timeSinceLevelLoad + addToTime;
				break;
			case TimerType.Countdown:
				playTime = countdownDelay - Time.time + countdownAmount;
			
				if( playTime < 0 )
				{
					currentTimer = TimerType.Inactive;
				}
				break;
			case TimerType.Realtime:
				playTime = Time.realtimeSinceStartup + addToTime;
				break;
			default:
				break;
		}
		
		if( playTime > delayTime )
		{
			delayTime = playTime + delayRate;
		}
	}
	#endregion Cycle Methods
	
	#region Public Methods
	/// <summary>
	/// Starts the time as Play Time..
	/// </summary>
	public void StartTimer()
	{
		startTime = Time.time;
		addToTime = 0f;
		continueTime = 0f;
		currentTimer = TimerType.Playtime;
	}
	
	/// <summary>
	/// Starts the time as the load time.
	/// </summary>
	public void FromLoad()
	{
			fromLoadTime = Time.timeSinceLevelLoad;
			startTime = 0f;
			addToTime = 0f;
			currentTimer = TimerType.FromLoad;
	}
	
	/// <summary>
	/// Stops the timer.
	/// </summary>
	public void StopTimer()
	{
		stopTime = playTime;
		addToTime = 0;
		currentTimer = TimerType.Inactive;
	}
	
	/// <summary>
	/// Changes the time scale.
	/// </summary>
	/// <param name='scale'>New time scale.</param>
	public void ChangeScale(float scale)
	{
		Time.timeScale = scale;
	}
	
	/// <summary>
	/// Resumes the timer.
	/// </summary>
	public void Resume()
	{
		continueTime = Time.time - playTime;
		startTime = 0f;
		addToTime = 0f;
		currentTimer = TimerType.Playtime;
	}
	
	/// <summary>
	/// Reset the timer.
	/// </summary>
	public void Reset()
	{
		stopTime = 0f;
		playTime = 0f;
		continueTime = 0f;
		addToTime = 0f;
		currentTimer = TimerType.Inactive;
	}
	
	/// <summary>
	/// Countdown the specified time.
	/// </summary>
	/// <param name='time'>Time for countdown.</param>
	public void Countdown(float time)
	{
		countdownDelay = Time.time;
		countdownAmount = time;
		addToTime = 0;
	}
	
	/// <summary>
	/// Adds to timer.
	/// </summary>
	/// <param name='time'>Time.</param>
	public void AddToTimer(float time)
	{
		addToTime += time;
	}
	
	/// <summary>
	/// Sets the extra time.
	/// </summary>
	/// <param name='time'>Time.</param>
	public void SetExtraTime(float time)
	{
		addToTime = time;
	}

	/// <summary>
	/// Starts the counter using realtime.
	/// </summary>
	public void RealTime()
	{
		realTime = Time.realtimeSinceStartup;
		startTime = 0f;
		addToTime = 0f;
		currentTimer = TimerType.Realtime;
	}
	
	/// <summary>
	/// Changes the timer to the specified type.
	/// </summary>
	/// <param name='type'>New type.</param>
	/// <param name='countdownTime'>Countdown time for countdown timer.</param>
	public void ChangeTimer(TimerType type, float countdownTime = 0f)
	{
		switch(type)
		{
			case TimerType.Playtime:
				StartTimer();
				break;
			case TimerType.FromLoad:
				FromLoad();
				break;
			case TimerType.Countdown:
				Countdown(countdownTime);
				break;
			case TimerType.Realtime:
				RealTime();
				break;
			case TimerType.Inactive:
				StopTimer();
				break;			
		}
	}
	#endregion Public Methods
}
