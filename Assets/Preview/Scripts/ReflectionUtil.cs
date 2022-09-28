using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public static class ReflectionUtil 
{
    [InitializeOnLoadMethod]
    public static void Test ()
    {
      foreach (var i in GetAllInstancesInProject (typeof (Component)))
        Debug.Log (i);
    }
    
    public static UnityEngine.Object[] GetAllAttributesObject ()
    {
      return Transform.FindObjectsOfType <UnityEngine.Object>()
      .Where (obj => {
        
        return false;
      })
      .ToArray ();
    }
    

    public static UnityEngine.Object[] GetAllInstancesInProject (Type type)
    {
        // since these are assets and we need to actually load them
        string [] guids = AssetDatabase.FindAssets("t:" + type);
        UnityEngine.Object [] instances = new UnityEngine.Object[guids.Length];
        
        for(int i =0; i < guids.Length; i++) 
        { 
          var path = AssetDatabase.GUIDToAssetPath(guids[i]);
          instances [i] = AssetDatabase.LoadAssetAtPath (path, type);
        }    

        return instances;
    } 

    
} 