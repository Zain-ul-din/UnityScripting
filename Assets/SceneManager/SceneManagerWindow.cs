
/*
  OPEN_SOURCE
  Contribute on GitHub : https://github.com/Zain-ul-din/UnityScripting
*/

using System.IO;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEditor;

public class SceneManagerWindow : EditorWindow
{
    /// <summary>
    /// Draws Scene Manager Window 
    /// </summary>
    [MenuItem ("Randoms/SceneManager")]
    private static void DrawWindow ()
    {
      bool drawFixedWindow = false;
      EditorWindow window = GetWindow(typeof(SceneManagerWindow),drawFixedWindow,"Scene Manager");
      window.Show();
    }
    
    /// <summary>
    /// GUI startup
    /// </summary>
    private void OnGUI ()
    {
      #if UNITY_EDITOR  
       SceneLoaderWindow ();
       UpdateSceneManagerScript ();
      #endif
    }

    /// <summary>
    /// Scene Loader Ui Renderer
    /// </summary>
    private void SceneLoaderWindow ()
    {
      var scenesPath = SceneManagerUtil.BuildScenesPath ();
      if (scenesPath.Count == 0)
      {
       GUILayout.Label("Warning : No Scene Added So Far", EditorStyles.helpBox);
       if (GUILayout.Button ("Add Scenes"))
       {
        EditorWindow window = GetWindow (typeof (BuildPlayerWindow));
        window.Show ();
       }
      }

      foreach (var scenePath in scenesPath )
      {
        if (GUILayout.Button (SceneManagerUtil.GetSceneName(scenePath), EditorStyles.miniButton)) 
        {
          EditorSceneManager.OpenScene (scenePath);
          // TODODS: Add Scene in-side window Option :-)
        } 
      }
      
      GUILayout.Space (30);
      if (GUILayout.Button ("Refresh"))
      {
        AssetDatabase.Refresh ();
      }

      GUILayout.Label("SceneManager Window", EditorStyles.centeredGreyMiniLabel);  
    } 
    
    /// <summary>
    /// Updates changes in script
    /// </summary>
    private static void UpdateSceneManagerScript ()
    {
      string scriptPath = SceneManagerUtil.GetScriptPath ("SceneLoaderManager.cs");
      if (scriptPath == "") return;
      string fileContent = File.ReadAllText (scriptPath);
      string newSceneNameEnum  = "";
      foreach (string path in SceneManagerUtil.BuildScenesPath()) 
       newSceneNameEnum += SceneManagerUtil.GetSceneName (path) + ",\n";
      SceneManagerUtil.UpdateSceneLoaderScript (scriptPath, newSceneNameEnum);
    }

}

/// Utilities
public static class SceneManagerUtil 
{
    /// <summary>
    /// Returns all scenes path in build
    /// </summary>
    public static List <string> BuildScenesPath ()
    {
      List <string> scenes = new List<string> ();
      int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings; 
      for (int i = 0 ; i < sceneCount ; i += 1)
      {
        string scenePath = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i);
        scenes.Add (scenePath);
      }
      return scenes;
    }

    /// <summary>
    /// Returns Scene name
    /// </summary>
    public static string GetSceneName (string scenePath) => Path.GetFileNameWithoutExtension(scenePath);

    /// <summary>
    /// Returns script abs path
    /// <summary>
    public static string GetScriptPath (string scriptName) 
    {
      string[] res = System.IO.Directory.GetFiles(Application.dataPath, scriptName, SearchOption.AllDirectories);
      return res.Length > 0 ? res[0].Replace ("\\", "/") : "";
    }
    
    /// <summary>
    /// Keeps SceneLoaderManager Up to date
    /// <summmary>
    public static void UpdateSceneLoaderScript (string scriptPath, string enumVal)
    {
      string fileContent 
      = 
@"public static class SceneLoaderManager 
{
  public enum SceneName 
  {
$
  }
  
  /// <summary>
  /// Loads Scene
  /// </summary>
  public static void LoadScene (SceneName sceneName)
  {
    if (System.Enum.GetValues (typeof (SceneName)).Length == 0) return;
    UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName.ToString());
  }
}";   
      File.WriteAllText (scriptPath, fileContent.Replace ("$",enumVal));
    }
}

