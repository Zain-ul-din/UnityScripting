using UnityEditor;

namespace Randoms.Editor.Layouts
{
    /// <summary>
    ///  Base class for All Custom GUILayOuts
    /// </summary>
    public abstract class RandomsGUILayoutBase <T> 
    {
        private bool initLock;
  
        /// <summary>
        /// calls once on Layout Render 
        /// </summary>
        public virtual void Init () {}
    
        /// <summary>
        /// Draws GUI Layout
        /// </summary>
        public virtual void DrawLayout (ref T target, SerializedObject serializedObject) 
        {
            if (!initLock)
            {
                Init ();
                initLock = true;
            } 
        }
    
        public RandomsGUILayoutBase () {}
    }
}




