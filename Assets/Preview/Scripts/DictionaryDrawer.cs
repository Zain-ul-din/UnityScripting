using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[AttributeUsage (AttributeTargets.Field)]
public class ShowInInspector : Attribute
{
    public ShowInInspector () {}
}

[CustomPropertyDrawer (typeof (ShowInInspector))]
public class DictionaryDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUILayout.Button ("Dictionary");
    }
}



