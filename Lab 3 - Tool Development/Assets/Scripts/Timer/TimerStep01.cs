using UnityEngine;
using System.Collections;

public class TimerStep01 : MonoBehaviour 
{
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
		if( Input.GetKeyDown(KeyCode.A) )
		{
			print(Time.time);
		}
	}
	#endregion Game Cycle
}
