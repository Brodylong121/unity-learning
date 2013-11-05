using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class ScriptCreator : MonoBehaviour 
{
	[MenuItem ("Project Tools/Create New Script &#s")]
	public static void MenuCreateScript()
	{
		string className = "NewScript";
		string path = Application.dataPath + "/Scripts/" + className + ".cs";
		
		if( File.Exists(path) )
		{
			Debug.Log("Error: Script '" + path + "' already exists.");
			return;
		}
		
		StreamWriter sw = File.CreateText(path);
		
		sw.WriteLine("using UnityEngine;");
		sw.WriteLine("");
		sw.WriteLine("public class " + className + " : MonoBehaviour");
		sw.WriteLine("{");
		sw.WriteLine("	#region Inspector Variables");
		sw.WriteLine("	#endregion Inspector Variables");
		sw.WriteLine("");
		sw.WriteLine("	#region Private Attributes");
		sw.WriteLine("	#endregion Private Attributes");
		sw.WriteLine("");
		sw.WriteLine("	#region Properties");
		sw.WriteLine("	#endregion Properties");
		sw.WriteLine("");
		sw.WriteLine("	#region Game Methods");
		sw.WriteLine("	/// <summary>");
		sw.WriteLine("	/// Initializes this instance.");
		sw.WriteLine("	/// </summary>");
		sw.WriteLine("	void Start()");
		sw.WriteLine("	{");
		sw.WriteLine("	}");
		sw.WriteLine("");
		sw.WriteLine("	/// <summary>");
		sw.WriteLine("	/// Update is called once every frame.");
		sw.WriteLine("	/// </summary>");
		sw.WriteLine("	void Update()");
		sw.WriteLine("	{");
		sw.WriteLine("	}");
		sw.WriteLine("");
		sw.WriteLine("	/// <summary>");
		sw.WriteLine("	/// Draws the GUI for this script.");
		sw.WriteLine("	/// </summary>");
		sw.WriteLine("	void OnGUI()");
		sw.WriteLine("	{");
		sw.WriteLine("	}");
		sw.WriteLine("	#endregion Game Methods");
		sw.WriteLine("");
		sw.WriteLine("	#region Public Methods");
		sw.WriteLine("	#endregion Public Methods");
		sw.WriteLine("");
		sw.WriteLine("	#region Private Methods");
		sw.WriteLine("	#endregion Private Methods");
		sw.WriteLine("}");
		
		sw.Close();
		
		AssetDatabase.Refresh();
	}
}
