using UnityEngine;
using UnityEditor;
using System.IO;

public class PathTool : ScriptableObject
{
	[MenuItem("Tools/System/ShowPath")]
	static void ShowPath()
	{
		EditorUtility.DisplayDialog("Path", 
        "CURRENT: " 
        +" "+ System.Environment.GetEnvironmentVariable("PATH")
        , "OK", "");
	}
    
    
 
    [MenuItem("Tools/System/SetPathDefault")]
    static void SetPathDefault()
    {
        var name = "PATH";
        var PATH = System.Environment.GetEnvironmentVariable(name);
        var value = "/usr/bin:/bin:/usr/sbin:/sbin";
        var target = System.EnvironmentVariableTarget.Process;
        System.Environment.SetEnvironmentVariable(name, value, target);
    }
    
    
    //    [MenuItem("Tools/System/SetPathMono")]
    //static void SetPathMono()
    //{
    //    var name = "PATH";
    //    var PATH = System.Environment.GetEnvironmentVariable(name);
    //    var MonoPath = Path.Combine(EditorApplication.applicationContentsPath, "Mono/bin");
    //    var value = PATH + ":" + MonoPath;
    //    var target = System.EnvironmentVariableTarget.Process;
    //        System.Environment.SetEnvironmentVariable(name, value, target);
    //}
    

    
    
    
}//class


