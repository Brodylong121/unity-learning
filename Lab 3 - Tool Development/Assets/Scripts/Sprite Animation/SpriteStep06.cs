using UnityEngine;
using System.Collections;

public class SpriteStep06 : MonoBehaviour 
{
	#region Inspector Variables
	public int columns = 1; // u
	public int rows = 1; // v
	public float framesPerSecond = 8.0f;
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
		index = index % (columns * rows);
		
		// Transforms index in current column and row.
		int u =  index % columns;
		int v = (index / columns);
		
		// Calculates size and offset.
		Vector2 size = new Vector2( 1.0f / columns, 1.0f / rows );
		Vector2 offset = new Vector2( u * size.x, (1 - size.y) - (v * size.y) );
		
		// Sets values on the texture.
		renderer.material.mainTextureOffset = offset;
		renderer.material.mainTextureScale = size;
	}
	#endregion Game Cycle
}
