using System;

namespace _Steppes.Source.Scripts.Input
{
    [Serializable]
    public class Button : Input
    {
        
        public override bool IsPressed()
        {
            return UnityEngine.Input.GetButton(_inputName);
        }

        public override bool IsPressedDown()
        {
            return UnityEngine.Input.GetButtonDown(_inputName);
        }

        public override bool IsReleased()
        {
            return UnityEngine.Input.GetButtonUp(_inputName);
        }

        public override float GetValue()
        {
            return UnityEngine.Input.GetButton(_inputName) ? 0 : 1;
        }
    }
}