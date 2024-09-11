using UnityEngine;

namespace Dajjsand.Views.Bullets
{
    public interface IBulletStrategy
    {
        void UpdateMovement(Transform selfTransform);
        bool OnHit(Collision other);
    }
}