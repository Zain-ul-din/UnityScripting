using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Randoms.Editor.Layouts
{
    using Util;
    using Helper;
    using Editor = UnityEditor.Editor;
    
    /// <summary>
    /// Preview Layout
    /// </summary>
    public class PreviewLayout <T> : RandomsGUILayoutBase<T> where T : UnityEngine.Object
    {
        public      GUIStyle      previewWindowStyle;
        public      bool          drawObjectPreviewWindow;
        public      bool          allowSceneObjects;
        public      string        fieldName;
        public      int           previewWindowWidth;
        public      int           previewWindowHeight;
        
        
        private bool toggleState;
        private Editor previewWindow;
        private bool canUpdatePreview;
        public PreviewLayout(string fieldName)
        {
            this.fieldName          =  fieldName;
            toggleState             =  false;
            drawObjectPreviewWindow =  true;
            allowSceneObjects       =  true;
            previewWindowStyle      =  GUIStyleUtil.ContainerOuterShadow;
            previewWindowWidth      =  100;
            previewWindowHeight     =  100;
        }

        public override void Init()
        { }
        
        public override void DrawLayout (ref T target, SerializedObject serializedObject) 
        {
            base.DrawLayout(ref target, serializedObject);
            GUILayout.BeginVertical(GUIStyleUtil.CardStyleMini);
            {
                GUILayout.Label(fieldName, GUIStyleUtil.BoldTitle);
                
                GUILayout.BeginHorizontal();
                {
                    EditorGUI.BeginChangeCheck();
                    {
                      target = (T)EditorGUILayout.ObjectField(target, typeof(T), allowSceneObjects);  
                    }
                    if (EditorGUI.EndChangeCheck()) previewWindow = Editor.CreateEditor(target);
                    
                    GUILayout.Space(10);
                    var dropDownBtnTexture = (Texture)GUIUtil.GetTextureOfType(typeof(GameObject));
                    if (GUILayout.Button(dropDownBtnTexture, GUIStyleUtil.MiniUtilButton, GUILayout.Width(30)))
                    {
                        toggleState = !toggleState;
                    }
                }
                GUILayout.EndHorizontal();

                if (!target || !toggleState)
                {
                    GUILayout.EndVertical();
                    return;
                }
                
                if (previewWindow == null )
                    previewWindow = Editor.CreateEditor(target);

                if (drawObjectPreviewWindow)
                    previewWindow.OnPreviewGUI(GUILayoutUtility.GetRect(100, 100),
                        previewWindowStyle);
                
                GUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button("Edit", GUIStyleUtil.MiniButtonMid))
                    {
                        EditorHelper.OpenInspectorWindow(target);
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }
    }
    
    
}

