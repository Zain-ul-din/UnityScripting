using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class MyScriptWindow : EditorWindow
{
    [MenuItem("Window/Custom Tools/Enable")]
    public static void Enable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }
 
    [MenuItem("Window/Custom Tools/Disable")]
    public static void Disable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }
    
    private static void OnSceneGUI(SceneView sceneview)
    {
        Debug.Log ("Scene View");
        Handles.BeginGUI();
 
        if (GUILayout.Button("Button"))
            Debug.Log("Button Clicked");

        Handles.ArrowHandleCap (0, -new Vector3 (0,0,0), Quaternion.identity, 100, EventType.MouseDown);    
 
        Handles.EndGUI();
    }
}

