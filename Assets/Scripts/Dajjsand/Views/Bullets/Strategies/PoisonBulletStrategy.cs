using Dajjsand.Views.Base;
using UnityEngine;

namespace Dajjsand.Views.Bullets.Strategies
{
    public class PoisonBulletStrategy : IBulletStrategy
    {
        private const int PoisonDamage = 1;
        private const int RepeatsCount = 3;
        private const float DamageOnceTimer = 1f;

        public void UpdateMovement(Transform selfTransform) { }

        public bool OnHit(Collision other)
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable != null) // Player and Enemies
                damageable.ApplyPeriodicDamage(PoisonDamage, RepeatsCount, DamageOnceTimer);

            return true;
        }
    }
}