using System;
using UnityEngine.Events;

namespace _Steppes.Source.Scripts.Input
{
    [Serializable]
    public abstract class Input
    {
        public delegate void InputDelegate(float value);

        [Serializable]
        public class InputEvent : UnityEvent<float>
        {
        }


        public static float _DEADZONE = 0.02f;

        public string _inputName;

        public InputEvent WhilePressed;
        public InputEvent WhenPressedDown;
        public InputEvent WhenReleased;
        public InputDelegate _WhilePressed;
        public InputDelegate _WhenPressedDown;
        public InputDelegate _WhenReleased;

        protected float _previousValue;

        public void Update()
        {
            float value = GetValue();

            if (IsPressed())
            {
                WhilePressed?.Invoke(value);
                _WhilePressed?.Invoke(value);
            }

            if (IsPressedDown())
            {
                WhenPressedDown?.Invoke(value);
                _WhenPressedDown?.Invoke(value);
            }

            if (IsReleased())
            {
                WhenReleased?.Invoke(value);
                _WhenReleased?.Invoke(value);
            }

            _previousValue = value;
        }

        public abstract bool IsPressed();
        public abstract bool IsPressedDown();
        public abstract bool IsReleased();
        public abstract float GetValue();
    }
}