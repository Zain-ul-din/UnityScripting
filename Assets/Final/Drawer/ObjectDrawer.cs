using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Randoms.Editor.Internal 
{
    using Internals.Reflection;
    using Editor = UnityEditor.Editor;
    
    
    
    [CanEditMultipleObjects]
    [CustomEditor (typeof (UnityEngine.Object), true)]
    public class ObjectDrawer : Editor
    {

        public  readonly  List  <FieldInfo>  fieldInfos           =     new  List  <FieldInfo>  ();        


        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            // Do Reflection stuff 
            
            IEnumerable <FieldInfo> info = target.GetFieldsInfo 
            (
                (FieldInfo f) =>
                {
                    return f.IsDefined (typeof (IRandomsAttribute), true);
                }
            );
             
            foreach (FieldInfo i in info)
            {
                // is public
                if (!i.IsStatic && i.IsPublic)
                {
                    fieldInfos.Add (i);
                }
            }
 
        }
        
        public override void OnInspectorGUI()
        {
            
            
            DateTime before = DateTime.Now;

            // DrawDefaultInspector ();
            
            serializedObject.Update ();
            
            foreach (FieldInfo i in fieldInfos)
            {
                // Draw Buttons
                if (i.IsDefined (typeof(HelperBoxAttribute)))
                {
                    var helperAttr = i.GetCustomAttribute (typeof (HelperBoxAttribute)) as HelperBoxAttribute;
                    GUILayout.Label (helperAttr.message, EditorStyles.helpBox);
                    EditorGUILayout.PropertyField (serializedObject.FindProperty (i.Name));
                }
                else if (i.IsDefined (typeof (ShowIfAttribute)))
                {
                    var showIfAttr = i.GetCustomAttribute (typeof (ShowIfAttribute)) as ShowIfAttribute;
                    if (target.GetField <bool> (showIfAttr.booleanFieldName))
                    {
                        EditorGUILayout.PropertyField (serializedObject.FindProperty (i.Name));
                    }
                } 
                
            }
            
            EditorGUILayout.PropertyField (serializedObject.FindProperty ("myStr"));
            


            // foreach (FieldInfo i in privateFieldsInfo)
            // {
            //     if (i.IsDefined (typeof (ShowInInspector)))
            //     {
            //         // EditorGUILayout.ObjectField ()
            //     }
            // }

            serializedObject.ApplyModifiedProperties ();
            DateTime after = DateTime.Now; 
            TimeSpan duration = after.Subtract(before);
            Debug.Log("Duration in milliseconds: " + duration.Milliseconds);
        }
    }
}



