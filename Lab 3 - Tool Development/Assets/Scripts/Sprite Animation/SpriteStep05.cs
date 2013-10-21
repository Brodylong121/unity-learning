using UnityEngine;
using System.Collections;

public class SpriteStep05 : MonoBehaviour 
{
	#region Inspector Variables
	public int columns = 1; // u
	public int rows = 1; // v
	//public int index = 0;
	public int currentRow = 0;
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
		int index = Mathf.RoundToInt(Time.time * framesPerSecond);

		index =  index % columns;
		currentRow = currentRow % rows;
		
		Vector2 size = new Vector2( 1.0f / columns, 1.0f / rows );
		Vector2 offset = new Vector2( index * size.x, currentRow * size.y );
		
		renderer.material.mainTextureOffset = offset;
		renderer.material.mainTextureScale = size;
	}
	#endregion Game Cycle
}
