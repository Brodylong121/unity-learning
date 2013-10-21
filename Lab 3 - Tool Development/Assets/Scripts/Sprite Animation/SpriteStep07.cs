using UnityEngine;
using System.Collections;

public class SpriteStep07 : MonoBehaviour 
{
	#region Inspector Variables
	public int columnSize = 1; // u
	public int rowSize = 1; // v
	public float framesPerSecond = 8.0f;
	
	public int columnFrameStart = 0;
	public int rowFrameStart = 0;
	public int totalFrames = 1;
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
		// Constrols FPS
		int index = Mathf.RoundToInt(Time.time * framesPerSecond);
		// Modulate
		index = index % totalFrames;
		
		// Transforms index in current column and row.
		int u = index % columnSize;
		int v = index / columnSize;
		
		// Calculates size and offset.
		Vector2 size = new Vector2( 1.0f / columnSize, 1.0f / rowSize );
		Vector2 offset = new Vector2( ( u + columnFrameStart ) * size.x, (1 - size.y) - ( (v + rowFrameStart) * size.y) );
		
		// Sets values on the texture.
		renderer.material.mainTextureOffset = offset;
		renderer.material.mainTextureScale = size;
	}
	#endregion Game Cycle
}
