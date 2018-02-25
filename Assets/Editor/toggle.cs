using UnityEngine;
using UnityEditor;

public class toggle : ScriptableObject
{
 [MenuItem ("Custom/Selection/Deactivate objects %#d")]
 static void DoDeactivate()
 {
     foreach (GameObject go in Selection.gameObjects)
     {
         go.active = false;
     }
 }
 [MenuItem("Custom/Selection/Activate objects %#a")]
 static void DoActivate()
 {
     foreach (GameObject go in Selection.gameObjects)
     {
         go.active = true;
     }
 }
}
