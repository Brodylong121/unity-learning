using UnityEngine;
using System.Collections;

public class SpriteAnimation : MonoBehaviour 
{
	#region Methods
	/// <summary>
	/// Animates the sprite.
	/// </summary>
	/// <param name='columnSize'>Column size.</param>
	/// <param name='rowSize'>Row size.</param>
	/// <param name='columnFrameStart'>Column frame start.</param>
	/// <param name='rowFrameStart'>Row frame start.</param>
	/// <param name='totalFrames'>Total frames.</param>
	/// <param name='framesPerSecond'>Frames per second.</param>
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
