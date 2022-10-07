using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Randoms.Editor
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class HelperBoxAttribute : IRandomsAttribute
    {
        public HelperBoxAttribute (string message)
        {
            this.message = message;
        }

        public readonly string message;
    }  
}


