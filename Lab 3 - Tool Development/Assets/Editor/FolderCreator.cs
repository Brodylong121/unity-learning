using System.IO;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Generates a default folder structure in the project.
/// </summary>
public class FolderCreator : MonoBehaviour
{
	#region Menu Items
	/// <summary>
	/// Menu Item to the Create Folder Structure option.
	/// </summary>
	[MenuItem ("Project Tools/Create Folder Structure")]
	public static void MenuCreateFolders()
	{
		string assets = Application.dataPath + "/";
		
		Directory.CreateDirectory(assets + "Audio");
		Directory.CreateDirectory(assets + "Materials");
		Directory.CreateDirectory(assets + "Prefabs");
		Directory.CreateDirectory(assets + "Scripts");
		Directory.CreateDirectory(assets + "Meshes");
		Directory.CreateDirectory(assets + "Textures");
		Directory.CreateDirectory(assets + "Scripts");
		Directory.CreateDirectory(assets + "Fonts");
		Directory.CreateDirectory(assets + "Resources");
		Directory.CreateDirectory(assets + "Shaders");
		Directory.CreateDirectory(assets + "Packages");
		Directory.CreateDirectory(assets + "Physics");
		
		AssetDatabase.Refresh();
	}
	#endregion Menu Items
}
