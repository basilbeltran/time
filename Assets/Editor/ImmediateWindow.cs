/*
 * ImmediateWindow.cs
 * Copyright (c) 2012 Nick Gravelyn
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of 
 * this software and associated documentation files (the "Software"), to deal in 
 * the Software without restriction, including without limitation the rights to use, 
 * copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the 
 * Software, and to permit persons to whom the Software is furnished to do so, 
 * subject to the following conditions:
 
 * The above copyright notice and this permission notice shall be included in all 
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
 
using UnityEngine;
using UnityEditor;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using basil.util;
using basil.things;
using System;

public class ImmediateWindow : EditorWindow
{

    // script text
    private string scriptText = string.Empty;
 
    // cache of last method we compiled so repeat executions only incur a single compilation
    private MethodInfo lastScriptMethod;
 
    // position of scroll view
    private Vector2 scrollPos;
 

    void OnGUI()
    {
        // start the scroll view
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
 
        // show the script field
        //string newScriptText = EditorGUILayout.TextArea(scriptText);
        string newScriptText = EditorGUILayout.TextArea(scriptText, GUILayout.Height(position.height - 5));
        if (newScriptText != scriptText)
        {
            // if the script changed, update our cached version and null out our cached method
            scriptText = newScriptText;
            lastScriptMethod = null;
        }
 
        // store if the GUI is enabled so we can restore it later
        bool guiEnabled = GUI.enabled;
 
        // disable the GUI if the script text is empty
        GUI.enabled = guiEnabled && !string.IsNullOrEmpty(scriptText);
 
 
 
 
        // show the execute button
        if (GUILayout.Button("Execute"))
        {
            // if our script method needs compiling
            if (lastScriptMethod == null)
            {
               // U.Log("immediate using" + System.Environment.GetEnvironmentVariable("PATH"));
                
                // create and configure the code provider
                var codeProvider = new CSharpCodeProvider();
                
                
                var options = new CompilerParameters();
                options.GenerateInMemory = true;
                options.GenerateExecutable = false;
                // bring in system libraries
                options.ReferencedAssemblies.Add("System.dll");
                options.ReferencedAssemblies.Add("System.Core.dll");
                 U.Log(" System loc: "+typeof(Activator).Assembly.Location);

                // bring in Unity assemblies
                options.ReferencedAssemblies.Add(typeof(EditorWindow).Assembly.Location);
				options.ReferencedAssemblies.Add(typeof(Transform).Assembly.Location);
                U.Log(" EditorWindow loc: "+typeof(Transform).Assembly.Location);
                U.Log(" Transform loc: "+typeof(EditorWindow).Assembly.Location);
				//U.Log(" loc: "+typeof(MakeTime).Assembly.Location);
                                
                //U.Log(" Transform loc: "+typeof(Me).Assembly.Location);            
                //options.ReferencedAssemblies.Add(typeof(Me).Assembly.Location);

                options.ReferencedAssemblies.Add("/Users/basilbeltran/Projects/basil/basil/bin/basil.dll");
				// bring in your assemblies
				//options.ReferencedAssemblies.Add(typeof(MakeTime).Assembly.Location);

                
 
                // compile an assembly from our source code
                var result = codeProvider.CompileAssemblyFromSource(options, string.Format(scriptFormat, scriptText));
 
                // log any errors we got
                if (result.Errors.Count > 0)
                {
                    foreach (CompilerError error in result.Errors)
                    {
                        // the magic -11 on the line is to compensate for usings and class wrapper around the user script code.
                        // subtracting 11 from it will give the user the line numbers in their code.
                        //Debug.LogError(string.Format("Immediate Compiler Error ({0}): {1}", error.Line - 11, error.ErrorText));   
                        Debug.LogError(string.Format(error.ToString() ) ) ;   

                     }
                }
 
                // otherwise use reflection to pull out our action method so we can invoke it
                else
                {
                    var type = result.CompiledAssembly.GetType("ImmediateWindowCodeWrapper");
                    lastScriptMethod = type.GetMethod("PerformAction", BindingFlags.Public | BindingFlags.Static);
                }
            }
 
            // if we have a compiled method, invoke it
            if (lastScriptMethod != null)
                lastScriptMethod.Invoke(null, null);
        }

        // restore the GUI
        GUI.enabled = guiEnabled;
 
        // close the scroll view
        EditorGUILayout.EndScrollView();
    }
 
    [MenuItem("Window/Immediate")]
    static void Init()
    {
        // get the window, show it, and hand it focus
        var window = EditorWindow.GetWindow<ImmediateWindow>("Immediate", false);
        window.Show();
        window.Focus();
    }

//cant seem to be able to reference my code from this script runner
//using basil.util;
//using basil.things;


    // script we wrap around user entered code
    static readonly string scriptFormat = @"
using System; 
using System.Reflection; 
using System.Runtime.CompilerServices; 
using System.Collections; 
using System.Collections.Generic; 
using System.Text; 
using System.Linq;

using UnityEngine; 
using UnityEditor; 
using UnityEngine.SceneManagement;




public static class ImmediateWindowCodeWrapper
{{
    public static void PerformAction()
    {{
        // user code goes here
        {0};
    }}

}}"

;
}
