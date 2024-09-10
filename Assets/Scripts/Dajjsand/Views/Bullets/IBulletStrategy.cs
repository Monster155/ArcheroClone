using UnityEngine;

namespace Dajjsand.Views.Bullets
{
    public interface IBulletStrategy
    {
        void Init(Transform selfTransform, float speed, int damage);
        void Move();
        bool OnHit(Collision other);
    }
}