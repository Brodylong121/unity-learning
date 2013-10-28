using UnityEngine;
using System.Collections;

public class PrintableTimer : Timer 
{
	#region Inspector Variables
	public GameObject animationFont01;
	public GameObject animationFont02;
	public GameObject animationFont03;
	public GameObject animationFont04;
	
	public GUISkin marioGui;
	#endregion Inspector Variables
	
	#region Game Cycle
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () 
	{
	
	}
	
	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	public override void Update () 
	{
		AnimateSprite( animationFont01, 10, 1, 0, 0, 10, "font1");
		AnimateSprite( animationFont02, 10, 1, 0, 0, 10, "font2");
		AnimateSprite( animationFont03, 10, 1, 0, 0, 10, "font3");
		AnimateSprite( animationFont04, 10, 1, 0, 0, 10, "font4");
		
		base.Update();		
		
		// Start Time.		
		if( Input.GetKeyDown(KeyCode.Alpha1) )
		{
			StartTimer();
		}
		
		// From Load Time.
		if( Input.GetKeyDown(KeyCode.Alpha2) )
		{
			FromLoad();
		}
		
		// Stops time.
		if( Input.GetKeyDown(KeyCode.Alpha3) )
		{
			StopTimer();
		}
		
		// Time scale.
		if( Input.GetKeyDown(KeyCode.Alpha4) )
		{
			ChangeScale(0f);
		}
		else if( Input.GetKeyUp(KeyCode.Alpha4) )
		{
			ChangeScale(1f);
		}
		
		// Continue time.
		if( Input.GetKeyDown(KeyCode.Alpha5) )
		{
			Resume();
		}
		
		// Reset time.
		if( Input.GetKeyDown(KeyCode.Alpha6) )
		{
			Reset();
		}
		
		// Countdown
		if( Input.GetKeyDown(KeyCode.Alpha7) )
		{
			Countdown(5);
		}

		// Adds to timer a single amount, once.
		if( Input.GetKeyDown(KeyCode.Alpha8) )
		{
			SetExtraTime(1f);
		}
		
		// Adds to timer every time.
		if( Input.GetKeyDown(KeyCode.Alpha9) )
		{
			AddToTimer(1f);
		}
		
		// Gets real time.
		if( Input.GetKeyDown(KeyCode.Alpha0) )
		{
			RealTime();
		}
	}
	
	void OnGUI()
	{		
		GUILayout.Label("PlayTime " + playTime.ToString("f4") );
		GUILayout.Label("1 - Start the Time");
		GUILayout.Label("2 - From Load Time");
		GUILayout.Label("3 - Stop Time");
		GUILayout.Label("4 - Pause Game Time");
		GUILayout.Label("5 - Continue Time");
		GUILayout.Label("6 - Reset Time");
		GUILayout.Label("7 - Count Down Time");
		GUILayout.Label("8 - Add to Time Once");
		GUILayout.Label("9 - Add to Time Multi");
		GUILayout.Label("0 - Time Since Startup");
		
		GUILayout.Label("Minutes:     " + minutes.ToString("f0") );
		GUILayout.Label("Seconds:     " + seconds.ToString("f0") );
		GUILayout.Label("Miliseconds: " + fractions.ToString("f0") );
		
		GUILayout.Label("Delay Time " + delayTime.ToString("f4") );
		GUILayout.Label("Continue Time " + continueTime.ToString("f4") );
		
		GUI.skin = marioGui;
		
		GUI.Label( new Rect( Screen.width / 2, 10, 1000, 100), "" + playTime.ToString("f1"));
		
	}
	#endregion Game Cycle
	
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
	public void AnimateSprite( GameObject spriteObject, int columnSize, int rowSize, int columnFrameStart, int rowFrameStart, int totalFrames, string type)
	{
		// Modulate
		int index = Mathf.CeilToInt(playTime);
		
		int font1 = index % 10;
		int font2 = ( (index - font1 ) / 10 ) % 10;
		int font3 = ( (index - font1 ) / 100 ) % 10;
		int font4 = ( (index - font1 ) / 1000 ) % 10;
		
		if( type == "font1" ) index = font1;
		if( type == "font2" ) index = font2;
		if( type == "font3" ) index = font3;
		if( type == "font4" ) index = font4;
		
		// Transforms index in current column and row.
		int u = index % columnSize;
		int v = index / columnSize;
		
		// Calculates size and offset.
		Vector2 size = new Vector2( 1.0f / columnSize, 1.0f / rowSize );
		Vector2 offset = new Vector2( ( u + columnFrameStart ) * size.x, (1 - size.y) - ( (v + rowFrameStart) * size.y) );
		
		// Sets values on the texture.
		spriteObject.renderer.material.mainTextureOffset = offset;
		spriteObject.renderer.material.mainTextureScale = size;
		
		//renderer.material.SetTextureOffset("_BumpMap", offset);
		//renderer.material.SetTextureScale("_BumpMap", size);
	}
	#endregion Methods
}
