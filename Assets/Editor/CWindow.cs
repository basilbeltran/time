using UnityEngine; 
using UnityEditor; 
using System.IO; 
using UnityEngine.SceneManagement;

public class CWindow : EditorWindow { 
// script text 
private string scriptText = "UnityEngine.Debug.Log(\"Hello World\");" ;

     // reusable script file to store C# 
     string scriptName = "CWindowTemp";

    string newFileName;
    string tickleName;
    
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
         if (GUILayout.Button("random"))
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

         // a new file to help the editor refresh assets - didn't work because of the 
         System.Random sr = new System.Random();
         int rNum = sr.Next();
         string fileBase = scriptName;//+ rNum.ToString();
          newFileName = directoryLocation + fileBase + ".cs";
          


          //Clears the file for re-writing
         File.WriteAllText(newFileName, string.Empty);
         //This writes the new file but it will be empty
         using (StreamWriter newWriter = new StreamWriter(newFileName, true))
         {
             //The rest of this writes what you want your file to contain
             newWriter.WriteLine(string.Format(scriptFormat, scriptText, fileBase));  
         }

        forceRecompile(); // good luck

        AssetDatabase.ImportAsset( newFileName, ImportAssetOptions.ForceUpdate );

        //Tells us the class is done writing
         Debug.Log(newFileName + "  Done!");
         
         tickleName = directoryLocation + fileBase +rNum.ToString()+ ".cs";
         File.WriteAllText(tickleName, string.Empty);

         
         
        GameObject go = GameObject.FindGameObjectWithTag("static");

         MonoBehaviour mb = go.AddComponent<CWindowTemp>();
         //mb.hideFlags = HideFlags.HideInInspector;
         //mb.enabled = true;
         //mb.enabled = false; 
         DestroyImmediate(go.GetComponent<CWindowTemp>());


        //File.Delete(tickleName);

     }

     void forceRecompile()
    {
        AssetDatabase.StartAssetEditing();

            MonoScript script = AssetDatabase.LoadAssetAtPath(newFileName, typeof(MonoScript)) as MonoScript;
            if (script != null)
            {
                AssetDatabase.ImportAsset(newFileName);
            }
        
        AssetDatabase.StopAssetEditing();
    }


     // here is a template for your scripting... add or delete as needed
     static readonly string scriptFormat = @"

using System; using System.Reflection; 
using System.Runtime.CompilerServices; 
using System.Collections; 
using System.Collections.Generic; 
using System.Text; using System.Linq;

using UnityEngine; 
using UnityEditor; 
using UnityEngine.SceneManagement;

using basil.util;
using basil.things;

[ExecuteInEditMode] 
public class  {1} : MonoBehaviour 

{{ 


    public void OnEnable() 
    {{ 

            // user code goes here
            {0}; 
    }} 

}}";




} 
