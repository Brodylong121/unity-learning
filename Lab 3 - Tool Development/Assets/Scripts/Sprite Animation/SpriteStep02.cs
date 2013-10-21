using UnityEngine;
using System.Collections;

public class SpriteStep02 : MonoBehaviour 
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
		renderer.material.mainTextureOffset = new Vector2(0.25f, 0f);
		renderer.material.mainTextureScale = new Vector2(0.0625f, 1f);
	}
	#endregion Game Cycle
}
