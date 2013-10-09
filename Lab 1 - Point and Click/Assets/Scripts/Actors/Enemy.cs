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
    /// Minimum respawn time
    /// </summary>
    public float minRespawnTime = 0.5f;

    /// <summary>
    /// Maximum respawn time
    /// </summary>
    public float maxRespawnTime = 2.0f;
	
	/// <summary>
	/// The color of the shape.
	/// </summary>
	public Color[] shapeColor;
	
	/// <summary>
	/// The explosion transform.
	/// </summary>
	public Transform explosion;
	
	/// <summary>
	/// How many points the enemy is worth.
	/// </summary>
	public int enemyPoints = 1;
	
	/// <summary>
	/// Time the object will blink after dying.
	/// </summary>
	public float blinkingSeconds = 3.0f;
	
	/// <summary>
	/// Time for each part of the blinking.
	/// </summary>
	public float blinkTime = 0.5f;
	#endregion Inspector Variables
	
	#region Private Variables
	/// <summary>
	/// The stored clicks number.
	/// </summary>
	private int storeClicks = 0;
	
	/// <summary>
	/// Seconds blinking.
	/// </summary>
	private float seconds = 0.0f;

    /// <summary>
    /// The respawn wait time.
    /// </summary>
    private float respawnWaitTime = 2.0f;
	
	/// <summary>
	/// Is the object blinking?
	/// </summary>
	private bool blinking = false;
	#endregion Private Variables
	
	#region Game Cycle Methods
	/// <summary>
	/// Initializes this instance.
	/// </summary>
	void Start()
	{
		// Stores initial click count.
		storeClicks = numberOfClicks;
		
		// Creates new random position for the game object.
		Vector3 position = new Vector3( Random.Range(-6f,6f), Random.Range(-4f,4f), 0);
		
		// Move the game object to a new location
		transform.position = position;
		
		RandomColor ();
	}
	
	/// <summary>
	/// Update is called every frame.
	/// </summary>
	void Update () 
	{
		if( numberOfClicks <= 0 && !blinking )
		{	
			// Blink for Blinking Seconds predefined time
			// After that, it will teleport the object to a random location.
			seconds = blinkingSeconds;
			blinking = true;
			InvokeRepeating("Blink", blinkTime, blinkTime);
		}
	}
	#endregion Game Cycle Methods
	
	#region Methods
	/// <summary>
	/// RespawnWaitTime is used to hide a game object for a set amount of time and then show it.
	/// </summary>
	IEnumerator RespawnWaitTime()
	{
        respawnWaitTime = Random.Range(minRespawnTime, maxRespawnTime);
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
	
	/// <summary>
	/// Blink the object.
	/// </summary>
	void Blink()
	{
		renderer.enabled = !renderer.enabled;
		seconds -= blinkTime;
		
		if( seconds <= 0f )
		{
			renderer.enabled = true;
			
			// Instantiates an explosion.
			if( explosion != null )
			{
				Instantiate(explosion, transform.position, transform.rotation);				
			}
			if( audio != null )
			{
				audio.Play();
			}
			
			// Creates new random position for the game object.
			Vector3 position = new Vector3( Random.Range(-6f,6f), Random.Range(-4f,4f), 0);
			
			// Move the game object to a new location
			transform.position = position;
			
			numberOfClicks = storeClicks;
			
			CancelInvoke("Blink");
			blinking = false;
			
			StartCoroutine(RespawnWaitTime());
		}
	}
	#endregion Methods
}
