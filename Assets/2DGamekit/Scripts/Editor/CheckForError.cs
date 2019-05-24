using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using UnityEngine.Windows;
using Object = UnityEngine.Object;

[InitializeOnLoad]
public class CheckForError
{
    static CheckForError()
    {        
        if (File.Exists(Application.dataPath + "/../Library/CheckedForError"))
            return;

        EditorApplication.update += EditorUpdate;
    }
    
    static void EditorUpdate()
    {
        if (EditorApplication.isCompiling)
            return;

        var logEntries = System.Type.GetType("UnityEditor.LogEntries,UnityEditor.dll");
        var methods = logEntries.GetMethod("GetCountsByType", BindingFlags.Static|BindingFlags.Public);

        object[] arguments = { 0, 0, 0 };

        methods.Invoke(null, arguments);

        int errorCount = (int)(arguments[0]);

        if (errorCount > 0)
        {
            if (EditorUtility.DisplayDialog("Error", "Look like there is error in the project and that shouldn't happen on the first launch. Please, press ok to open the Unity forum to report your problem.", "Ok", "Cancel"))
            {
                Application.OpenURL("https://forum.unity3d.com");
            }
        }
          
        File.WriteAllBytes(Application.dataPath + "/../Library/CheckedForError", new byte[]{0});
        EditorApplication.update -= EditorUpdate;
    }
}
