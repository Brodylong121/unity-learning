using UnityEngine;
using System.Collections;

public class TimerStep09 : MonoBehaviour 
{
	#region Inspector Variables
	public float playTime = 0f;
	public float countdownDelay = 0f;
	public float countdownAmount = 10f;
	public bool timeActive = false;
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
			playTime = countdownDelay - Time.time + countdownAmount;
		}
		
		if( Input.GetKeyDown( KeyCode.Alpha7 ) )
		{
			countdownDelay = Time.time;
			timeActive = true;
		}
		if( playTime < 0f )
		{
			timeActive = false;
		}
	}
	
	void OnGUI()
	{
		GUILayout.Label("Play Time " + playTime.ToString("f3"));
	}
	#endregion Game Cycle
}
