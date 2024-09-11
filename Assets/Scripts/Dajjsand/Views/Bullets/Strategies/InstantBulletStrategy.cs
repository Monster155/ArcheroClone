using Dajjsand.Views.Base;
using UnityEngine;

namespace Dajjsand.Views.Bullets.Strategies
{
    public class InstantBulletStrategy : IBulletStrategy
    {
        private const int Damage = 1;

        public void UpdateMovement(Transform selfTransform) { }
        
        public bool OnHit(Collision other)
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable != null) // Player and Enemies
                damageable.ApplyDamage(Damage);

            return true;
        }
    }
}