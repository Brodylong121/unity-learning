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
		Directory.CreateDirectory(assets + "Audio/Music");
		Directory.CreateDirectory(assets + "Audio/SoundEffects");
		Directory.CreateDirectory(assets + "Editor");
		Directory.CreateDirectory(assets + "Fonts");
		Directory.CreateDirectory(assets + "Libraries");
		Directory.CreateDirectory(assets + "Materials");
		Directory.CreateDirectory(assets + "Models");
		Directory.CreateDirectory(assets + "Physics");
		Directory.CreateDirectory(assets + "Prefabs");
		Directory.CreateDirectory(assets + "Resources");
		Directory.CreateDirectory(assets + "Scenes");	
		Directory.CreateDirectory(assets + "Scripts");
		Directory.CreateDirectory(assets + "Shaders");
		Directory.CreateDirectory(assets + "Textures");	
		
		AssetDatabase.Refresh();
	}
	#endregion Menu Items
}
