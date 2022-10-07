using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Randoms.Editor;

using ShowInInspector = Randoms.Editor;

public class FinalExample : MonoBehaviour
{
    [ShowPreview] 
    public GameObject gameObj;
    [ShowPreview] 
    public Vector3    vector3;
    [ShowPreview] 
    public float      fval;
    [ShowPreview] 
    public int        iVal;
    
    [HelperBox ("Make it better")]
    [ShowPreview] 
    public string    iStr;
    
    [HelperBox ("Make it better")] 
    public int _class;

    [HelperBox ("Boolean Field")]
    public bool showTest;
    
    [ShowIf ("showTest")] public int _enum;
    
    [SerializeField] private string myStr; 
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        Debug.Log (iStr);  
    }
    
    
}

[System.Serializable]
public class CustomClass
{
    public int name;
}


