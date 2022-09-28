using System.Reflection;
using UnityEngine;
using UnityEditor;

namespace Randoms.Editor.Helper
{
  public static class EditorHelper
  {
    
    private readonly static System.Type inspectorWindowType;
    


    static EditorHelper ()
    {
      EditorHelper.inspectorWindowType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.InspectorWindow");
    }
    
    /// <summary>
    /// Opens a new inspector window for the specified object.
    /// </summary>
    /// <param name="unityObj">The unity object.</param>
    /// <exception cref="T:System.ArgumentNullException">unityObj</exception>
    public static void OpenInspectorWindow(UnityEngine.Object unityObj)
    {
        if (unityObj == null)
        {
            throw new System.ArgumentNullException("unityObj");
        }
        
        EditorWindow editorWindow = ScriptableObject.CreateInstance(EditorHelper.inspectorWindowType) as EditorWindow;
        editorWindow.Show();
        Object[] _objects = Selection.objects;
        Selection.activeObject = unityObj;
        EditorHelper.inspectorWindowType.GetProperty("isLocked", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy).GetSetMethod().Invoke(editorWindow, new object[] { true });
        Selection.objects = _objects;
    }

  }

} 
