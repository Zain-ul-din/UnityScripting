using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    namespace Randoms.LevelEditor 
{
       [CreateAssetMenu(menuName = "Randoms/EditorSO", fileName = "EditorSO")]
       public class LevelEditorSO : ScriptableObject 
     {
        [Header("Add Level Prefabs Here")] 
        public List<GameObject> levelPrefabs;
     }


       public class LevelPrefab 
     {
           public GameObject prefab;
     }  
}

