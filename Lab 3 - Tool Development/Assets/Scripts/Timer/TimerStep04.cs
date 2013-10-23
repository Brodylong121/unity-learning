using UnityEngine;
using System.Collections;

public class TimerStep04 : MonoBehaviour 
{
	#region Inspector Variables
	public float playTime = 0f;
	public float startTime = 0f;
	public float fromStartTime = 0f;
	
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
		if( timeActive )
		{
			playTime = Time.time;
		}
		
		if( Input.GetKeyDown(KeyCode.Alpha1) )
		{
			startTime = Time.time;
		}
		
		fromStartTime = Time.time - startTime;
	}
	
	void OnGUI()
	{
		GUILayout.Label("Play Time " + playTime.ToString("f3"));
		GUILayout.Label("Start Time " + startTime.ToString("f3"));
		GUILayout.Label("From Start Time " + fromStartTime.ToString("f3"));
		GUILayout.Label("Active " + timeActive.ToString());
	}
	#endregion Game Cycle
}
