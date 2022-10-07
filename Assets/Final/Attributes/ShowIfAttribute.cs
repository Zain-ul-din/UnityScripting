using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Randoms.Editor
{
    public class ShowIfAttribute : IRandomsAttribute
    {
        public ShowIfAttribute (string booleanFieldName)
        {
            this.booleanFieldName =  booleanFieldName;
        }

        public string booleanFieldName;
    }
}
