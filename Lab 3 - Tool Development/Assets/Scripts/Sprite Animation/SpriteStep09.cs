using UnityEngine;
using System.Collections;

public class SpriteStep09 : MonoBehaviour 
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
		AnimateSprite( 8, 2, 0, 0, 16, 12f);
	}
	#endregion Game Cycle
	
	#region Methods
	public void AnimateSprite( int columnSize, int rowSize, int columnFrameStart, int rowFrameStart, int totalFrames, float framesPerSecond)
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
		
		renderer.material.SetTextureOffset("_BumpMap", offset);
		renderer.material.SetTextureScale("_BumpMap", size);
	}
	#endregion Methods
}
