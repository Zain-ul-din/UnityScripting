using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using Randoms.Editor;
using Randoms.Editor.Util;
using Randoms.Editor.Helper;
using Randoms.Editor.Layouts;
using UnityEngine.UI;


[CustomEditor(typeof(UnityEditor_Preview))]
public class UnityEditor_PreviewWindow : RandomsEditor<UnityEditor_Preview>
{

    GameObject _gameObject;
    Editor _gameObjectEditor;
 
    GameObjectLayout gameObjectLayout;
    private PreviewLayout<GameObject> gameObjectPreview;
    private PreviewLayout<Image> imagePreview;
    TextureLayout<Image> imageLayout;
    TextureLayout<Sprite> spriteLayout;

    private static void GetTypeInfo<T>(T other) where T : MonoBehaviour
    {
        Type type = other.GetType();

        BindingFlags bindingFlags =
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.FlattenHierarchy;

        FieldInfo[] fieldInfo = type.GetFields(bindingFlags)
            .Where(FieldInfo => FieldInfo.IsDefined(typeof(WarnOnNullAttribute), true))
            .ToArray();


        foreach (FieldInfo info in fieldInfo)
        {
            var val = info.GetValue(other);
            try
            {
                if (val.ToString() == "null") Debug.LogWarning($"{info.Name} is not referenced!");
            }
            catch (NullReferenceException _)
            {
                Debug.LogWarning($"{info.Name} is not referenced!" + _.ToString());
            }
        }
    }

    Editor _;
    bool enumOpenState = false;
    bool doExpensiveTaskLock;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        {
            GUILayout.Button("Enum Fold", GUIStyleUtil.CardStyle);
            var _this = (UnityEditor_Preview)target;
            // Debug.Log(GetTypeInternals (ref _this, "dropDownValues"));
            if (GUILayout.Button("Click Me", GUIStyleUtil.ButtonMid))
            {
                // EditorHelper.OpenInspectorWindow (_this._gameObject);
            }

            if (!doExpensiveTaskLock)
            {
                Debug.Log("init");
                GetTypeInfo<UnityEditor_Preview>(_this);
                doExpensiveTaskLock = true;
                gameObjectLayout = new GameObjectLayout("MyObj");
            }


            // EditorGUILayout.PropertyField (serializedObject.FindProperty ("dropDownValues"));

            if (GUILayout.Button("dropDownValues", GUIStyleUtil.DropDownMiniButton))
            {
                enumOpenState = !enumOpenState;
            }

            if (enumOpenState)
            {
                foreach (var enumStr in Enum.GetValues(typeof(UnityEditor_Preview.DropDownMenuType)))
                    GUILayout.Label(enumStr.ToString(), GUIStyleUtil.Popup);
            }

            switch (_this.dropDownValues)
            {
                case UnityEditor_Preview.DropDownMenuType.val:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("intVal"));
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("stringVal"));
                    break;
                case UnityEditor_Preview.DropDownMenuType.list:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("list"));
                    break;
            }

            // EditorGUILayout.PropertyField (serializedObject.FindProperty ("_gameObject"));
            // if (gameObjectLayout == null) gameObjectLayout = new GameObjectLayout("MyObj");
            // gameObjectLayout.DrawLayout(ref _this.myObj, serializedObject);
            if (gameObjectPreview == null) gameObjectPreview = new PreviewLayout<GameObject>("MyObj");
            gameObjectPreview.DrawLayout(ref _this.myObj, serializedObject);
            
            GUILayout.Space(10);

            // if (imagePreview == null) imagePreview = new PreviewLayout<Image>("img");
            // imagePreview.DrawLayout(ref _this.img, serializedObject);
            
            if (imageLayout == null) imageLayout = new TextureLayout<Image>("img");
            imageLayout.DrawLayout(ref _this.img, serializedObject);

            GUILayout.Space(10);
            if (spriteLayout == null) spriteLayout = new TextureLayout<Sprite>("Sprite");
            spriteLayout.DrawLayout(ref _this.sprite, serializedObject);

            // _this.__gameObject = (_GameObject) EditorGUILayout.ObjectField (_this.__gameObject, _this._gameObject.GetType(), allowSceneObjects :false);
            // EditorGUILayout.PropertyField (serializedObject.FindProperty ("cam")); 


            // if (_gameObject.ToString () != _this._gameObject.ToString ())
            // {
            //   _gameObject = _this._gameObject;
            //   _gameObjectEditor = Editor.CreateEditor(_gameObject);
            // }

            // _gameObject = (_GameObject) EditorGUILayout.ObjectField(_gameObject, typeof(_GameObject), true);

            // GUILayout.BeginHorizontal ();

            // if (_gameObject != null)
            // {
            //   if (_gameObjectEditor == null)
            //     _gameObjectEditor = Editor.CreateEditor(_gameObject);

            //   // _gameObjectEditor.OnPreviewGUI(GUILayoutUtility.GetRect(20, 70), EditorStyles.whiteLabel);
            //   _gameObjectEditor.OnInteractivePreviewGUI(GUILayoutUtility.GetRect(100, 100), GUIStyleUtil.ContainerOuterShadow);
            // }

            // GUILayout.Space (5);

            // if (_gameObject != null)
            // {
            //   if (_gameObjectEditor == null)
            //     _gameObjectEditor = Editor.CreateEditor(_gameObject);

            //   // _gameObjectEditor.OnPreviewGUI(GUILayoutUtility.GetRect(20, 70), EditorStyles.whiteLabel);
            //   _gameObjectEditor.OnInteractivePreviewGUI(GUILayoutUtility.GetRect(100, 100), GUIStyleUtil.ContainerOuterShadow);
            // }

            // GUILayout.EndHorizontal ();

            // EditorGUILayout.PropertyField (serializedObject.FindProperty ("texture2D"));

            // EditorGUILayout.ObjectField(
            //   "Thumbnail",                    // string
            //   _this.texture2D,                  // Texture2D
            //   typeof(Texture2D),              // Texture2D object, of course
            //   false                           // allowSceneObjects
            // );
        }
        serializedObject.ApplyModifiedProperties();
    }

    // /// <summary>
    // /// Called when the script is loaded or a value is changed in the
    // /// inspector (Called in the editor only).
    // /// </summary>
    // void OnValidate()
    // {

    // }
}


[AttributeUsage(AttributeTargets.Field)]
public class WarnOnNullAttribute : Attribute
{
    public WarnOnNullAttribute()  { }
}
