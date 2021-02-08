using System;
using UnityEngine;

namespace _Steppes.Source.Scripts.Input
{
    [Serializable]
    public class Trigger : Input
    {
        public override bool IsPressed()
        {
            return Mathf.Abs(UnityEngine.Input.GetAxis(_inputName)) > _DEADZONE;
        }

        public override bool IsPressedDown()
        {
            if (Mathf.Abs(_previousValue) > _DEADZONE)
                return false;
            return Mathf.Abs(_previousValue) > _DEADZONE;
        }

        public override bool IsReleased()
        {
            if (Mathf.Abs(_previousValue) < _DEADZONE)
                return false;
            return Mathf.Abs(_previousValue) < _DEADZONE;
        }

        public override float GetValue()
        {
            float value = UnityEngine.Input.GetAxis(_inputName);
            return Mathf.Abs(value) > _DEADZONE ? value : 0;
        }
    }
}