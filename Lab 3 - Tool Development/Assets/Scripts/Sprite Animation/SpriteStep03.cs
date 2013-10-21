using UnityEngine;
using System.Collections;

public class SpriteStep03 : MonoBehaviour 
{
	#region Inspector Variables
	public int tileX = 1; // u
	public int tileY = 1; // v
	#endregion Inspector Variables
	
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
		Vector2 size = new Vector2( 1.0f / tileX, 1.0f / tileY );
		renderer.material.mainTextureOffset = new Vector2(0.25f, 0f);
		renderer.material.mainTextureScale = size;
	}
	#endregion Game Cycle
}
