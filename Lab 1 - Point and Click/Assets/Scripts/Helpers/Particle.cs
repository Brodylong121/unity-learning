using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {


	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update () 
	{
		if( particleSystem != null && !particleSystem.IsAlive() )
		{
			Destroy(this.gameObject);
		}
	}
}
