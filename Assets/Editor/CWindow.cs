using UnityEngine; using UnityEditor; using System.IO; using UnityEngine.SceneManagement;

public class CWindow : EditorWindow { // script text private string scriptText = "UnityEngine.Debug.Log(\"Hello World\");" ;

     // reusable script file to store C# 
     string scriptName = "CWindowTemp";
     //the new script to execute
     private MonoBehaviour mb ;
     //a root object where we park the temporary MonoBehaviour component
     private GameObject go;
     // position of scroll view
     private Vector2 scrollPos;
     void OnGUI()
     {
         // start the scroll view
         scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
         // show the script field
         string newScriptText = EditorGUILayout.TextArea(scriptText, GUILayout.Height(position.height - 10));
         // close the scroll view
         EditorGUILayout.EndScrollView();
         if (newScriptText != scriptText)
         {
             // if the script changed, update our cached version and null out our cached method
             scriptText = newScriptText;
         }
         // store if the GUI is enabled so we can restore it later
         bool guiEnabled = GUI.enabled;
         // disable the GUI if the script text is empty
             GUI.enabled = guiEnabled && !string.IsNullOrEmpty(scriptText);
         // show the execute button
         if (GUILayout.Button("Run"))
         {
             UpdateScript(scriptText);
             // restore the GUI
             GUI.enabled = guiEnabled;
         }
     }// onGui
     [MenuItem("Window/CWindow")]
     static void Init()
     {
         //var window = GetWindow(EditorGUILayoutTextArea);
         //window.Show();
         // get the window, show it, and hand it focus
         var window = GetWindow<CWindow>("CWindow", false);
         window.Show();
         window.Focus();
     }
     public void UpdateScript(string scriptText)
     {
         //This is the directory where the file will be put
         //string directoryLocation = Application.dataPath + System.IO.Path.PathSeparator;
         string directoryLocation = Application.dataPath + "/Scripts/";
         //Clears the file for re-writing
         File.WriteAllText(directoryLocation + "CWindowTemp.cs", string.Empty);
         //This writes the new file but it will be empty
         using (StreamWriter newWriter = new StreamWriter(directoryLocation + "CWindowTemp.cs", true))
         {
             //The rest of this writes what you want your file to contain
             newWriter.WriteLine(string.Format(scriptFormat, scriptText));
         }
         //Tells us the class is done writing
         Debug.Log(Application.dataPath + "  Done!");
         //Refresh all the assets so the script loads properly
         AssetDatabase.Refresh();
         // Get the root object 
         go = SceneManager.GetActiveScene().GetRootGameObjects()[0];
         
         mb = go.AddComponent<CWindowTemp>();
         mb.hideFlags = HideFlags.HideInInspector;
         //enabling the behaviour will trigger the OnEnabled method with our code
         mb.enabled = true;
         mb.enabled = false; 
         DestroyImmediate(go.GetComponent<CWindowTemp>());
     }
     // here is a template for your scripting... add or delete as needed
     static readonly string scriptFormat = @"

using System; using System.Reflection; using System.Runtime.CompilerServices; using System.Collections; using System.Collections.Generic; using System.Text; using System.Linq;

using UnityEngine; using UnityEditor; using UnityEngine.SceneManagement;

using basil.util;

[ExecuteInEditMode] public class CWindowTemp : MonoBehaviour {{ public void OnEnable() {{ // user code goes here {0}; }} }}";

} 
