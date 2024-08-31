using System;
using UnityEngine;

namespace Dajjsand.Views.CollidingHandlers
{
    public class EscapeRoomDoorHandler : MonoBehaviour
    {
        public event Action PlayerCollide;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                PlayerCollide?.Invoke();
            }
        }
    }
}