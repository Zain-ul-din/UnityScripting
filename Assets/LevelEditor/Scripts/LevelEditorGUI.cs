using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*
 * DOCS Link
 * https://docs.unity3d.com/ScriptReference/EditorWindow.GetWindow.html
 * https://answers.unity.com/questions/282959/set-inspector-lock-by-code.html
 * https://docs.unity3d.com/ScriptReference/EditorGUI.html
 * https://docs.unity3d.com/ScriptReference/EditorGUILayout.html
*/

   namespace Randoms.LevelEditor 
{
     using Utilities;
     using EditorUtilities;
    
      public class LevelEditorGUI : EditorWindow 
    {
            /// <summary>
            /// /// Draws the GUI for the Level Editor.
            /// </summary>
            [MenuItem("Randoms/Level Editor")]
            private static void DrawWindow () 
          {
            bool drawFixedWindow = false;
            EditorWindow window = GetWindow(typeof(LevelEditorGUI),drawFixedWindow,"Level Editor");
            window.Show();
            OpenScriptAbleObjectInInspector();
            
          } 
            
            /// <summary>
            /// Draws the GUI for the Level Editor.
            /// </summary>
            private void OnGUI () 
          {
            GUILayout.Label("Level Editor", EditorStyles.boldLabel);
            GUILayout.Label("Here you can create and edit levels.", EditorStyles.label);
          }

            /// <summary>
            /// Opens ScriptableObject in Inspector
            /// </summary>
            private static void OpenScriptAbleObjectInInspector () 
          {
              const string editorSOPath = "EditorSO";
              var editorSO = Resources.Load<LevelEditorSO>(editorSOPath);
              Selection.activeObject = editorSO;
              EditorUtilities.LockInspector(true);
          }

            private void OnInspectorUpdate () 
          {
              Debug.Log("Updated");
          }
            
            
    }
}


