using System;
using UnityEngine;

namespace Dajjsand.Views.InputControllers
{
    public class MobileInputController : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        private void Update()
        {
            Horizontal = _joystick.Horizontal;
            Vertical = _joystick.Vertical;
        }
    }
}