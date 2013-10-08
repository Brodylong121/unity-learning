using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	#region Inspector Variables
	/// <summary>
	/// The number of clicks to destroy object.
	/// </summary>
	public int numberOfClicks = 2;
	
	/// <summary>
	/// The respawn wait time.
	/// </summary>
	public float respawnWaitTime = 2.0f;
	
	/// <summary>
	/// The color of the shape.
	/// </summary>
	public Color[] shapeColor;
	
	/// <summary>
	/// The explosion transform.
	/// </summary>
	public Transform explosion;
	#endregion Inspector Variables
	
	#region Private Variables
	/// <summary>
	/// The stored clicks number.
	/// </summary>
	private int storeClicks = 0;
	#endregion Private Variables
	
	#region Game Cycle Methods
	/// <summary>
	/// Initializes this instance.
	/// </summary>
	void Start()
	{
		storeClicks = numberOfClicks;
	}
	
	/// <summary>
	/// Update is called every frame.
	/// </summary>
	void Update () 
	{
		if( numberOfClicks <= 0 )
		{
			// Instantiates an explosion.
			if( explosion != null )
			{
				Instantiate(explosion, transform.position, transform.rotation);
			}
			
			// Creates new random position for the game object.
			Vector3 position = new Vector3( Random.Range(-6f,6f), Random.Range(-4f,4f), 0);
			
			//Makes object disapear and show after defined time.
			StartCoroutine(RespawnWaitTime());
			
			// Move the game object to a new location
			transform.position = position;
			
			numberOfClicks = storeClicks;
		}
	}
	#endregion Game Cycle Methods
	
	#region Methods
	/// <summary>
	/// RespawnWaitTime is used to hide a game object for a set amount of time and then show it.
	/// </summary>
	IEnumerator RespawnWaitTime()
	{
		renderer.enabled = false;
		RandomColor();
		yield return new WaitForSeconds(respawnWaitTime);
		renderer.enabled = true;		
	}
	
	/// <summary>
	/// RandomColor is used to change out the material of a game object.
	/// </summary>
	void RandomColor()
	{
		if( shapeColor.Length > 0 )
		{
			var newColor = Random.Range(0, shapeColor.Length );
			renderer.material.color = shapeColor[newColor];
		}
	}
	#endregion Methods
}
