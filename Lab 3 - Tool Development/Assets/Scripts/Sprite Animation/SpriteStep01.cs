using UnityEngine;
using System.Collections;

public class SpriteStep01 : MonoBehaviour 
{
	#region Inspector Variables
	public float scrollSpeed = 0.1f;
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
		float offset = Time.time * scrollSpeed;
		renderer.material.mainTextureOffset = new Vector2(offset, 0);
	}
	#endregion Game Cycle
}
