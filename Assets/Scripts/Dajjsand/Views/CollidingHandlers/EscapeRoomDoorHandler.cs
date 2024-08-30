using System;
using UnityEngine;

namespace Dajjsand.Views.CollidingHandlers
{
    public class EscapeRoomDoorHandler : MonoBehaviour
    {
        public event Action PlayerCollide;

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.tag.Equals("Player"))
            {
                PlayerCollide?.Invoke();
            }
        }
    }
}