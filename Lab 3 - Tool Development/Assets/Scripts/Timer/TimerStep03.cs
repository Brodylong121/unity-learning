using UnityEngine;
using System.Collections;

public class TimerStep03 : MonoBehaviour
{
	#region Inspector Variables
	public float playTime = 0f;
	public float days = 0f;
	public float hours = 0f;
	public float minutes = 0f;
	public float seconds = 0f;
	public float fractions = 0f;
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
		playTime = Time.time;
		days = ( playTime / 86400);
		hours = (playTime / 3600) % 24;
		minutes = (playTime / 60) % 60;
		seconds = (playTime % 60);
		fractions = (playTime * 1000 ) % 1000;
	}
	
	void OnGUI()
	{
		GUILayout.Label("Play Time " + playTime);
		GUILayout.Label("Minutes " + minutes.ToString("f0"));
		GUILayout.Label("Seconds " + seconds.ToString("f0"));
		GUILayout.Label("Miliseconds " + fractions.ToString("f0"));
	}
	#endregion Game Cycle
}