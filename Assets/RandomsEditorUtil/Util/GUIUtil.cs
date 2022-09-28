using UnityEngine;
using UnityEditor;

namespace Randoms.Editor.Util
{
    public static class GUIUtil
    {
        /// <summary>
        /// Returns Texture of Type
        /// </summary>
        public static Texture GetTextureOfType (System.Type type)
        {
            return EditorGUIUtility.ObjectContent (null, type).image;
        }
        
    } 
}


