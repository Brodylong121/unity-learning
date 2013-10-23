using UnityEngine;
using System.Collections;

public class TimerStep11 : MonoBehaviour 
{
	#region Inspector Variables
	public float playTime = 0f;
	public float addToTimeAmount = 0f;
	public float timeAmount = 0f;

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
			playTime = Time.time + addToTimeAmount;
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
	}
	
	void OnGUI()
	{
		GUILayout.Label("Play Time " + playTime.ToString("f3"));
	}
	#endregion Game Cycle
}
