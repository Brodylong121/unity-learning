using UnityEngine;
using UnityEditor;
using System.Collections;

public class MaterialCreator : MonoBehaviour 
{
	#region Menu Items
	/// <summary>
	/// Creates the prefab for the selection.
	/// </summary>
	[MenuItem ("Project Tools/Create Material &#m")]
	public static void MenuCreateMaterial()
	{
		// Gets selected objects from the game view.
		Object[] objects = Selection.GetFiltered(typeof(Texture2D), SelectionMode.Assets);
		
		foreach( Object obj in objects )
		{
			string name = obj.name;
			string path = "Assets/Materials/" + name + ".mat";
			
			// Checks if prefab already exists.
			if( AssetDatabase.LoadAssetAtPath(path, typeof(Material) ) != null )
			{
				// Asks if user wants to overwrite the existing prefab.
				if( EditorUtility.DisplayDialog("Caution", "Material '" + name + "' already exists. Do you want to overwrite it?", "Yes", "No") )
				{
					CreateMaterial(obj as Texture2D, path);
				}
			}
			else
			{
				CreateMaterial(obj as Texture2D, path);
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
	private static void CreateMaterial(Texture2D obj, string path)
	{
		// Create empty prefab and replace with existing object.
		AssetDatabase.CreateAsset(new Material(Shader.Find("Diffuse")), path);
		Material material = AssetDatabase.LoadAssetAtPath(path, typeof(Material)) as Material;
		material.mainTexture = obj;
		
		// Refresh the Database.
		AssetDatabase.Refresh();
	}
	#endregion Methods
}
