
/*
  OPEN_SOURCE
  Contribute on GitHub : https://github.com/Zain-ul-din/UnityScripting
  TODOS: https://stackoverflow.com/questions/73749813/how-to-unfocus-guilayout-textfield-onclick-outside
*/

#if UNITY_EDITOR

using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEditor;

public class SceneManagerWindow : EditorWindow
{
    string searchText = "";

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
      SceneLoaderWindow ();
      UpdateSceneManagerScript ();
    }
    
    Vector2 scrollPos;

    /// <summary>
    /// Scene Loader Ui Renderer
    /// </summary>
    private void SceneLoaderWindow ()
    {
      var scenesPath = SceneManagerUtil.BuildScenesPath ();
      var filterScenesPath = scenesPath.Where (path => {
       return SceneManagerUtil.GetSceneName(path).ToLower().Contains (searchText.ToLower());
      }).ToArray();
      
      GUILayout.Space (10);

      if (scenesPath.Count == 0)
      {
       GUILayout.Label("Warning : No Scene Added So Far", EditorStyles.helpBox);
       if (GUILayout.Button ("Add Scenes"))
       {
        EditorWindow window = GetWindow (typeof (BuildPlayerWindow));
        window.Show ();
       }
      }
      else 
      {
        searchText = SceneManagerUtil.LabeledTextField ("Search Scene : ", searchText, 5);
        if (filterScenesPath.Length == 0)
        {
         GUILayout.Button ("Not Found", EditorStyles.centeredGreyMiniLabel);
        }
      }

      scrollPos = GUILayout.BeginScrollView(scrollPos, false, false, GUIStyle.none, GUI.skin.verticalScrollbar);
      GUILayout.Space (10);

      foreach (var scenePath in filterScenesPath)
      {
        GUILayout.BeginHorizontal ();
        GUILayout.Space (5);
        if (GUILayout.Button (SceneManagerUtil.GetSceneName(scenePath), EditorStyles.miniButton)) 
        {
          EditorSceneManager.OpenScene (scenePath);
        } 

        GUILayout.Space (5);
        if (GUILayout.Button ("-", EditorStyles.miniButtonMid, GUILayout.Width (50)))
        {
          SceneManagerUtil.RemoveSceneFromBuild (scenePath);
          AssetDatabase.SaveAssets ();
        }

        GUILayout.Space (5);
        GUILayout.EndHorizontal ();
        GUILayout.Space (5);
      }

      GUILayout.Space (20);
      EditorGUILayout.EndScrollView ();
      
      GUILayout.Space (20);
      
      GUILayout.BeginHorizontal ();

      if (GUILayout.Button ("Open Scene Editor",EditorStyles.miniButtonMid))
      {
        EditorWindow window = GetWindow (typeof (SceneEditorWindow), true);
        window.Show ();
      }
      
      if (GUILayout.Button ("Refresh", EditorStyles.miniButtonMid,GUILayout.Width (60)))
      {
        AssetDatabase.SaveAssets ();
      }
      
      if (GUILayout.Button ("Reload", EditorStyles.miniButtonMid, GUILayout.Width (60)))
      {
        AssetDatabase.Refresh ();
      }

      GUILayout.EndHorizontal ();
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
      string newSceneNameEnum = "";
      foreach (string path in SceneManagerUtil.BuildScenesPath()) 
       newSceneNameEnum += "   " + SceneManagerUtil.GetSceneName (path) + "\n, ";
      SceneManagerUtil.UpdateSceneLoaderScript (scriptPath, newSceneNameEnum);
    }

}

public class SceneEditorWindow : EditorWindow
{
  string searchText = "";

  void OnGUI()
  {
    RenderWindow();
  }
  Vector2 scrollPos, scrollPosition;
  /// <summary>
  /// Render main window
  /// </summary>
  private void RenderWindow ()
  {
    var scenesInfo = SceneManagerUtil.GetFilesInfoOfType ("*.unity");
    SceneManagerUtil.FileInfo[] filterInfo = scenesInfo.Where (scene => scene.fileName.ToLower ().Contains (searchText.ToLower())).ToArray ();
    
    scrollPos = EditorGUILayout.BeginScrollView(scrollPos, true, false, GUILayout.Width(this.position.width ), GUILayout.Height(this.position.height));
    Header(filterInfo);
    
    if (filterInfo.Length  == 0)
    {
      GUILayout.Button ("Not Found", EditorStyles.centeredGreyMiniLabel);
    }

    foreach (SceneManagerUtil.FileInfo info in filterInfo) 
    {
      GUILayout.BeginHorizontal();
      GUILayout.Space (30);
      
      if (GUILayout.Button(info.fileName, UnityEditor.EditorStyles.miniButtonLeft, GUILayout.Width(300)))
      {
        EditorSceneManager.OpenScene (info.relativepath);
      }
      
      GUILayout.Space (30);

      if (GUILayout.Button("+", UnityEditor.EditorStyles.miniButtonRight, GUILayout.Width(20)))
      {
        SceneManagerUtil.AddSceneToBuild (info.relativepath);
        AssetDatabase.SaveAssets ();
      }
      
      if (GUILayout.Button("-", UnityEditor.EditorStyles.miniButtonRight, GUILayout.Width(20)))
      {  
        SceneManagerUtil.RemoveSceneFromBuild(info.relativepath);
        AssetDatabase.SaveAssets ();
      }
      
      if (GUILayout.Button("Focus", UnityEditor.EditorStyles.miniButtonRight, GUILayout.Width(50)))
      {  
        SceneManagerUtil.FocusOnPath (info.relativepath);
      }

      GUILayout.EndHorizontal();
    }

    GUILayout.Space (10);
    GUILayout.Label("SceneManager Window", EditorStyles.centeredGreyMiniLabel);   
    EditorGUILayout.EndScrollView();   
  }
  
  /// <summary>
  /// Window Header
  /// </summary>
  private void Header (SceneManagerUtil.FileInfo[] filterInfos)
  {
    GUILayout.Space (30);
    GUILayout.BeginHorizontal ();
    
    GUILayout.Space (5);
    if (GUILayout.Button ("Show Build",EditorStyles.miniButtonMid))
    {
      EditorWindow window = GetWindow (typeof (BuildPlayerWindow),false);
      window.Show ();
    }
    
    GUILayout.Space (5); 
    if (GUILayout.Button ("Add All",EditorStyles.miniButtonMid))
    {
      // var scenesInfo = SceneManagerUtil.GetFilesInfoOfType ("*.unity");
      // filterInfos.ForEach (scene => SceneManagerUtil.AddSceneToBuild (scene.relativepath));
      foreach (SceneManagerUtil.FileInfo info in filterInfos) SceneManagerUtil.AddSceneToBuild (info.relativepath);
      AssetDatabase.SaveAssets ();
    }
    
    GUILayout.Space (5); 
    if (GUILayout.Button ("Remove All",EditorStyles.miniButtonMid))
    {
      // var scenesInfo = SceneManagerUtil.GetFilesInfoOfType ("*.unity");
      // scenesInfo.ForEach (scene => SceneManagerUtil.RemoveSceneFromBuild (scene.relativepath));
      foreach (SceneManagerUtil.FileInfo info in filterInfos) SceneManagerUtil.RemoveSceneFromBuild (info.relativepath);
      AssetDatabase.SaveAssets ();
    }

    GUILayout.EndHorizontal ();

    GUILayout.Space (20);
    searchText = SceneManagerUtil.LabeledTextField ("Search Scene : " , searchText);
    GUILayout.BeginHorizontal();
    if (filterInfos.Length > 0) GUILayout.Button ("Scenes",EditorStyles.centeredGreyMiniLabel,GUILayout.Width (300));
    GUILayout.EndHorizontal ();
    GUILayout.Space (5);
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
      string fileContent = 
      "public static class SceneLoaderManager {\n  public enum SceneName {\n$\n  }\n\n  public static void LoadScene (SceneName sceneName) {\n   if (System.Enum.GetValues (typeof (SceneName)).Length == 0) return;\n   UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName.ToString());\n  }\n}";   
      File.WriteAllText (scriptPath, fileContent.Replace ("$",enumVal));
    }

  /* IO APIS */

  /// <summary>
  /// Returns all files path of a given type
  /// USAGE : GetFilesOfType ("*.cs");
  /// </summary>
  public static string[] GetFilesOfType (string fileExtension) 
  {
    string root = Application.dataPath;
    return System.IO.Directory.GetFiles (root, fileExtension, System.IO.SearchOption.AllDirectories);
  }
   
  /// <summary>
  /// returns files info like: fileName, relative Path
  /// Usage : GetFilesInfoOfType ("*.cs")
  /// </summary>
  public static List <FileInfo> GetFilesInfoOfType (string fileExtension)
  {
    List<FileInfo> FilesInfo = new List<FileInfo> ();
    foreach (string fileAbsPath in GetFilesOfType (fileExtension))
    {
      string relativepath =  ("Assets" + fileAbsPath.Substring(Application.dataPath.Length)).Replace ("\\","/");
      string fileName = System.IO.Path.GetFileName (fileAbsPath).Split ('.')[0];
      FilesInfo.Add (new FileInfo {fileName = fileName, relativepath = relativepath});
    }
    return FilesInfo;
  } 

  /// <summary>
  /// Opens a path in project window
  /// <summary>
  public static void FocusOnPath (string path)
  {
    UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath(path, typeof(UnityEngine.Object));
    Selection.activeObject = obj;
    EditorGUIUtility.PingObject(obj);
  }
  
  public class FileInfo 
  {
    public string fileName, relativepath;
    public override string ToString () => $"SceneName : {fileName} , Path : {relativepath}";
  }     
  
  /// <summmary>
  /// Ads scene to build setting
  /// </summary>
  public static void AddSceneToBuild (string sceneRelativePath)
  {
    var original = EditorBuildSettings.scenes; 
    if (original.Where (scene => scene.path == sceneRelativePath).ToArray().Length > 0) return; // already in build settings
    var newSettings = new EditorBuildSettingsScene[original.Length + 1]; 
    System.Array.Copy(original, newSettings, original.Length); 
    var sceneToAdd = new EditorBuildSettingsScene(sceneRelativePath, true); 
    newSettings[newSettings.Length - 1] = sceneToAdd; 
    EditorBuildSettings.scenes = newSettings;
  }

  /// <summmary>
  /// Removes scene from build
  /// </summary>
  public static void RemoveSceneFromBuild (string sceneRelativePath)
  {
    EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
    EditorBuildSettings.scenes = scenes.Where (scene => scene.path != sceneRelativePath).ToArray();
  }

  /// <summary>
  /// Custom Search Field
  /// </summary>
  public static string LabeledTextField(string aLabel, string aText, int marginLeft = 30)
  {
    GUILayout.BeginHorizontal();
    GUILayout.Space (marginLeft);
    GUILayout.Label(aLabel, GUILayout.MaxWidth (100));
    aText = GUILayout.TextField(aText,GUILayout.Width (320));
    GUILayout.EndHorizontal();
    GUILayout.Space (5);
    return aText;
  }
}

#endif
