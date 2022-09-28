using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


public class UnityEditor_Preview : MonoBehaviour
{
    // Menus

    /*
      The MenuItem attribute allows you to add menu items to the main menu and inspector context menus.
    */
    [MenuItem("Randoms/Preview")]
    public static void CreateMenuAndRunFunc()
    {
        Debug.Log("Randoms Editor Preview!!");
    }

    /*
      The ContextMenu attribute allows you to add commands to the context menu.
      In the inspector of the attached script. When the user selects the context menu, the function will be executed.
      This is most useful for automatically setting up Scene data from the script. The function has to be non-static.
    */
    [ContextMenu("Randoms/RemoveThis")]
    public void RemoveThisScriptFromObject()
    {
        DestroyImmediate(this);
    }

    public enum DropDownMenuType
    {
        val,
        list
    }

    public DropDownMenuType dropDownValues;
    public int intVal;
    public string stringVal;
    [SerializeField] private List<string> list;
    [WarnOnNull] public GameObject myObj;
    public Camera cam;
    KeyValuePair<int, string> keyValPair;
 
    public Texture2D texture2D;

    public Image img;

    public Sprite sprite;

    private GameObject _personalGameObject;
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Debug.Log(myObj);
        Instantiate(myObj, Vector3.zero, Quaternion.identity);
    }
}