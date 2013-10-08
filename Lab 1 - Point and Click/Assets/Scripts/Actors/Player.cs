using UnityEngine;
using System.Collections;

/// <summary>
/// Player script.
/// </summary>
public class Player : MonoBehaviour 
{	
	#region Inspector Variables
	/// <summary>
	/// Allows the designer to set a tag in the inspector.
	/// </summary>
	public string tagName;
	/// <summary>
	/// The lenght of the ray for a raycast.
	/// </summary>
	public float rayDistance = 10f;
	#endregion Inspector Variables
	
	#region Private Variables
	#endregion Private Variables
	
	#region Game Cycle Methods
	/// <summary>
	/// Update is called every frame.
	/// </summary>
	void Update () 
	{
		// Use the mouse button to select Game Objects in the scene.
		if( Input.GetMouseButtonDown(0) )
		{
			//Raycast hit information.
			RaycastHit hit;
			
			//Get mouse position.
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			// Cast a ray against all colliders in the scene.
			if( Physics.Raycast(ray, out hit, rayDistance) )
			{
				if( hit.transform.tag == tagName )
				{
					Enemy enemy = (Enemy) hit.transform.GetComponent("Enemy");
					enemy.numberOfClicks--;
				}
			}
		}
	}
	#endregion Game Cycle Methods
}
