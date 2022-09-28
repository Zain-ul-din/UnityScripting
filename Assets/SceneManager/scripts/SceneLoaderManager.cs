namespace Randoms.SceneManger 
{
 public static class SceneLoaderManager
 {
  public enum SceneName
  {
   GridSystem,
   Preview,
   SceneManagerDemo,
   Test_1,
   Test_101,
   Test_102,
   Test_103,
   Test_104,
   Test_105,
   Test_106,
   Test_107,
   Test_10,
   Test_108,
   Test_109,
   Test_11,
   Test_110,
   Test_111,
   Test_112,
   Test_113,
   Test_114,
   Test_123,
   Test_124,
   Test_125,
   Test_138,
   Test_139,
   Test_143,
   Test_144,
   Test_151,
   Test_152,
  }

  public static void LoadScene (SceneName sceneName) 
  {
   if (System.Enum.GetValues (typeof (SceneName)).Length == 0) return;
   UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName.ToString());
  }

 }
}