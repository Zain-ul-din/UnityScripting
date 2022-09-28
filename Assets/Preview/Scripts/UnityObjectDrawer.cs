using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Randoms.Editor.Util;

[CustomPropertyDrawer (typeof (Object))]
public class UnityObjectDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Debug.Log (fieldInfo);
        GUILayout.BeginHorizontal ();
        {
         if (GUILayout.Button ("Edit", GUIStyleUtil.ButtonRight))
         {
           Debug.Log ("Hello");
         }

        }
        GUILayout.EndHorizontal (); 
    }

}


