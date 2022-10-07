using System;

namespace Randoms.Editor
{
    [AttributeUsage (AttributeTargets.Method)]
    public class ButtonAttribute:  IRandomsAttribute
    {
        public ButtonAttribute (string btnText)
        {
            this.btnText = btnText;
        }
        
        public string btnText;
    }
}



