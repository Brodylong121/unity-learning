using UnityEngine;
using System.Collections;

public class SpriteStep10 : MonoBehaviour 
{
	#region Game Cycle
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () 
	{
	
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update () 
	{
		SpriteAnimation animation = GetComponent("SpriteAnimation") as SpriteAnimation;
		
		if( Input.GetKey(KeyCode.D) )
		{
			animation.AnimateSprite( 8, 2, 0, 0, 16, 12f );
		}
	}
	#endregion Game Cycle
}
