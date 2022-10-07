using System;
using System.Collections;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Randoms.Internals.Reflection
{
    /// <summary>
    /// Reflection Extension Methods 
    /// </summary>
    public static class ReflectionUtil 
    {
        

        /// <summary>
        /// Returns All Fields info
        /// </summary>
        public static IEnumerable <FieldInfo> GetFieldsInfo (this UnityEngine.Object target, Func <FieldInfo, bool> filter)
        {
            Type targetTypeInfo = target.GetType ();
            
            IEnumerable <FieldInfo> fields = targetTypeInfo
            .GetFields (ReflectionUtil.fieldsBindingFlags)
            .Where (filter);
 
            foreach (var field in fields)
            {
                yield return field;
            }
        }

        
        /// <summary>
        /// Returns Field Info
        /// </summary>
        public static FieldInfo GetFieldInfo (this UnityEngine.Object target, string FieldName, BindingFlags flags)
        {
            Type targetTypeInfo = target.GetType ();
            return targetTypeInfo.GetField (FieldName, flags);
        }  
        

        /// <summary>
        /// Returns Non Static System.Type Field
        /// </summary>
        public static T GetField <T> (this UnityEngine.Object target, string fieldName) 
        {
            FieldInfo fieldInfo = ReflectionUtil.GetFieldInfo (target, fieldName, ReflectionUtil.NonStaticfieldBindingFlags);
            if (fieldInfo == null)
            {
                throw new NullReferenceException ();
            }
            
            var fieldValue = fieldInfo.GetValue (target);
            if (fieldValue.GetType () != typeof (T))
            {
                throw new InvalidCastException ();
            }

            return (T) fieldValue;
        }
        
        public static BindingFlags NonStaticfieldBindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly;
        public static BindingFlags fieldsBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly;
    }
}
