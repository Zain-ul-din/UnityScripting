using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;


namespace Randoms.Editor.Layouts
{
    using Randoms.Editor.Util;
    using Randoms.Editor.Helper;
    using Editor = UnityEditor.Editor;

    public sealed class TextureLayout <T> : RandomsGUILayoutBase <T> where T : UnityEngine.Object
    {
        public   string   fieldName;
        public   bool     allowSceneObjects;
        public   bool     showPreview;

        T               cache;
        bool            cacheChange;
        bool            toggleState;

        Editor          textureEditorWindow;
        
        public TextureLayout (string fieldName)
        {
          this.fieldName = fieldName;
          allowSceneObjects = true;
          showPreview = true;
        }

        public override void DrawLayout (ref T target, SerializedObject serializedObject) 
        {
            base.DrawLayout (ref target, serializedObject);
            cache = target;

            GUILayout.BeginVertical (GUIStyleUtil.CardStyleMini);
            {
                // Field Title
                GUILayout.Label (fieldName, GUIStyleUtil.BoldTitle);

                GUILayout.BeginHorizontal();
                {
                    // Object Picker
                    cache                      =  (T) EditorGUILayout.ObjectField(target, typeof(T), allowSceneObjects);
                    var dropDownBtnTexture     =  (Texture) GUIUtil.GetTextureOfType (typeof(T));
                    if (cache != target) 
                    {
                        cacheChange            = true; 
                        if (target = null) toggleState = false; 
                    }
                    target                     = cache;

                    GUILayout.Space (10);
                    if (GUILayout.Button (dropDownBtnTexture, GUIStyleUtil.MiniUtilButton, GUILayout.Width (30)))
                    {
                      toggleState = !toggleState;
                    } 
                }
                GUILayout.EndHorizontal ();

                if (!target)
                {
                    GUILayout.EndVertical ();
                    return;
                }
                else if (!toggleState)
                {
                    GUILayout.EndVertical ();
                    return;
                }

                GUILayout.Space (2);  
                
                if (textureEditorWindow == null || cacheChange)
                {
                    textureEditorWindow = Editor.CreateEditor (target);
                    cacheChange = false;
                }

                if (showPreview)
                    textureEditorWindow.OnInteractivePreviewGUI(GUILayoutUtility.GetRect(100, 100), GUIStyleUtil.CardStyleMini);     

                // Utilities Buttons
                GUILayout.BeginHorizontal ();
                {
                    if (GUILayout.Button ("Edit", GUIStyleUtil.MiniButtonMid))
                    {
                        EditorHelper.OpenInspectorWindow (target);  
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical ();
        }
    }
}


