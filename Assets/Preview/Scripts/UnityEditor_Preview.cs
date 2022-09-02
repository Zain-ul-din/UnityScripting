using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UnityEditor_Preview : MonoBehaviour {
    
    // Menus
    
    /*
      The MenuItem attribute allows you to add menu items to the main menu and inspector context menus.
    */
    [MenuItem("Randoms/Preview")]
    public static void CreateMenuAndRunFunc () { Debug.Log ("Randoms Editor Preview!!"); }
    
    /*
      The ContextMenu attribute allows you to add commands to the context menu.
      In the inspector of the attached script. When the user selects the context menu, the function will be executed.
      This is most useful for automatically setting up Scene data from the script. The function has to be non-static.
    */
    [ ContextMenu ("Randoms/RemoveThis")]
    public void RemoveThisScriptFromObject () { DestroyImmediate (this); }

     
    

}
