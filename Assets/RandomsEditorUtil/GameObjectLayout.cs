using UnityEngine;
using UnityEditor;

namespace Randoms.Editor.Layouts
{
    using Randoms.Editor.Util;
    using Randoms.Editor.Helper;
    using Editor = UnityEditor.Editor;

    /// <summary>
    /// GUI Layout for UnityEngine.GameObject
    /// </summary>
    public class GameObjectLayout : RandomsGUILayoutBase<GameObject>
    {
        public Rect previewWindowRect;
        public GUIStyle previewWindowStyle;
        public bool drawObjectPreviewWindow;
        public bool allowSceneObjects;
        public string fieldName;

        GameObject cache;
        Editor gameObjectPreviewWindow;
        bool toggleState;
        bool cacheChange;


        public override void Init()
        {
            cacheChange = false;
        }

        public override void DrawLayout(ref GameObject target, SerializedObject serializedObject)
        {
            base.DrawLayout(ref target, serializedObject);
            cache = target;

            GUILayout.BeginVertical(GUIStyleUtil.CardStyleMini);
            {
                // Field Title
                GUILayout.Label(fieldName, GUIStyleUtil.BoldTitle);

                // Object Picker
                GUILayout.BeginHorizontal();
                {
                    cache = (GameObject)EditorGUILayout.ObjectField(cache, typeof(GameObject), allowSceneObjects);
                    if (target != cache)
                    {
                        cacheChange = true;
                        if (target = null) toggleState = false;
                    }

                    target = cache;
                    var dropDownBtnTexture = (Texture)GUIUtil.GetTextureOfType(typeof(GameObject));

                    GUILayout.Space(10);
                    if (GUILayout.Button(dropDownBtnTexture, GUIStyleUtil.MiniUtilButton, GUILayout.Width(30)))
                    {
                        toggleState = !toggleState;
                    }
                }
                GUILayout.EndHorizontal();

                if (!cache)
                {
                    GUILayout.EndVertical();
                    return;
                }
                else if (!toggleState)
                {
                    GUILayout.EndVertical();
                    return;
                }

                // GameObject Preview
                if (drawObjectPreviewWindow && cache)
                    DrawGameObjectPreviewWindow(gameObjectPreviewWindow == null || cacheChange);
                cacheChange = false;

                // Utilities Buttons
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

        private void DrawGameObjectPreviewWindow(bool rePaint)
        {
            if (rePaint) gameObjectPreviewWindow = Editor.CreateEditor(cache);
            gameObjectPreviewWindow.OnInteractivePreviewGUI(GUILayoutUtility.GetRect(100, 100),
                GUIStyleUtil.ContainerOuterShadow);
        }

        public GameObjectLayout(string fieldName)
        {
            toggleState = false;
            this.fieldName = fieldName;
            drawObjectPreviewWindow = true;
            allowSceneObjects = true;
            previewWindowRect = GUILayoutUtility.GetRect(100, 100);
            previewWindowStyle = GUIStyleUtil.ContainerOuterShadow;
        }
    } // class
} // namespace