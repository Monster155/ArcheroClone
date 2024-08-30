using Dajjsand.Services.InputServices.Interfaces;
using UnityEngine;

namespace Dajjsand.Services.InputServices
{
    public class ComputerInputService : IInputService
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        
        public void Init()
        {
        }
    }
}