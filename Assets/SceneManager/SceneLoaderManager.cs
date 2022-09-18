public static class SceneLoaderManager {
  public enum SceneName {
   GridSystem
,    Preview
, 
  }

  public static void LoadScene (SceneName sceneName) {
   if (System.Enum.GetValues (typeof (SceneName)).Length == 0) return;
   UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName.ToString());
  }
}