using System.Collections;
using UnityEngine;
using UnityEditor;

public class PrefabCreator : MonoBehaviour 
{
	#region Menu Items
	/// <summary>
	/// Creates the prefab for the selection.
	/// </summary>
	[MenuItem ("Project Tools/Create Prefab &#p")]
	public static void MenuCreatePrefab()
	{
		// Gets selected objects from the game view.
		GameObject[] objects = Selection.gameObjects;
		
		foreach( GameObject obj in objects )
		{
			string name = obj.name;
			string path = "Assets/Prefabs/" + name + ".prefab";
			
			// Checks if prefab already exists.
			if( AssetDatabase.LoadAssetAtPath(path, typeof(GameObject) ) != null )
			{
				// Asks if user wants to overwrite the existing prefab.
				if( EditorUtility.DisplayDialog("Caution", "Prefab '" + name + "' already exists. Do you want to overwrite it?", "Yes", "No") )
				{
					CreatePrefab(obj, path);
				}
			}
			else
			{
				CreatePrefab(obj, path);
			}
		}
		
		
	}
	#endregion Menu Items
	
	#region Methods
	/// <summary>
	/// Creates the prefab from a Game Object.
	/// </summary>
	/// <param name='obj'>Game Object.</param>
	/// <param name='path'>Prefab path.</param>
	private static void CreatePrefab(GameObject obj, string path)
	{
		// Create empty prefab and replace with existing object.
		Object prefab = PrefabUtility.CreateEmptyPrefab(path);
		PrefabUtility.ReplacePrefab(obj, prefab);
		
		// Refresh the Database.
		AssetDatabase.Refresh();
		
		// Destroy existing object.
		DestroyImmediate( obj );
		// Replace object with prefab.
		PrefabUtility.InstantiatePrefab(prefab);
	}
	#endregion Methods
}