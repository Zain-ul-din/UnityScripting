using UnityEditor;

namespace Randoms.EditorUtilities {
    public static class EditorUtilities {
        
        /// <summary>
        /// Locks the inspector 
        /// </summary>
        /// <param name="locked"></param>
        public static void LockInspector (bool locked) {
            
            ActiveEditorTracker.sharedTracker.isLocked = locked ? 
            !ActiveEditorTracker.sharedTracker.isLocked
            : 
            ActiveEditorTracker.sharedTracker.isLocked;
        }
        
    }
}
