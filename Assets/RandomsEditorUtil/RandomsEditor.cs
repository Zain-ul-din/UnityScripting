using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

namespace Randoms.Editor
{
    using Editor = UnityEditor.Editor;

    /// <summary>
    /// Base class for Custom GUI Editor
    /// </summary>
    /// <typeparam name="T">Target Type</typeparam>
    public class RandomsEditor<T> : Editor
    {
        /// <summary>
        /// Target Field Info 
        /// </summary>
        private  Dictionary<string, FieldInfo> _instanceCache;
        
        /// <summary>
        /// Returns Field Info of Target 
        /// </summary>
        /// <param name="targetInstance">Targeted Instance</param>
        /// <param name="fieldName">declared Field</param>
        protected FieldInfo GetTypeInternals(ref T targetInstance, string fieldName)
        {
            if (_instanceCache == null)
            {
                _instanceCache = new Dictionary<string, FieldInfo>(); 
                GetInternals(ref targetInstance);
            }

            return _instanceCache[fieldName];
        }
        
        /// <summary>
        /// Finds all field on instance using <code>System.Reflection</code> and add to cache
        /// </summary>
        /// <param name="targetInstance">Instance</param>
        private void GetInternals(ref T targetInstance)
        {
            System.Type targetType = targetInstance.GetType();
            BindingFlags bindingFlags;
            {
                bindingFlags =
                    BindingFlags.Default
                    |
                    BindingFlags.Instance
                    |
                    BindingFlags.Public
                    |
                    BindingFlags.NonPublic
                    |
                    BindingFlags.FlattenHierarchy;
            }
            FieldInfo[] fieldInfos = targetType.GetFields(bindingFlags);
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                _instanceCache[fieldInfo.Name] = fieldInfo;
            }
        }
    }
}

