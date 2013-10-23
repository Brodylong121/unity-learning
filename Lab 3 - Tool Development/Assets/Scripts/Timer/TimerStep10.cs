using UnityEngine;
using System.Collections;

public class TimerStep10 : MonoBehaviour 
{
	#region Inspector Variables
	public float playTime = 0f;
	public float delayTime = 0f;
	public float delayedAmount = 0f;
	public int delaysCount = 0;
	
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
		
		// Delay time.
		if( playTime > delayTime )
		{
			delayTime = playTime + delayedAmount;
			delaysCount++;
		}
	}
	
	void OnGUI()
	{
		GUILayout.Label("Play Time " + playTime.ToString("f3"));
		GUILayout.Label("Delay Time " + delayTime.ToString("f3"));
		GUILayout.Label("Delay Count " + delaysCount);
	}
	#endregion Game Cycle
}
