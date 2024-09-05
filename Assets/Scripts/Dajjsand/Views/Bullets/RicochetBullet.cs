using System;
using Dajjsand.Views.Base;
using Dajjsand.Views.Bullets.Base;
using UnityEngine;

namespace Dajjsand.Views.Bullets
{
    public class RicochetBullet : Bullet
    {
        [SerializeField] private int _maxRicochetsCount = 3;

        private int _ricochetCounter;

        public override void Init(Transform muzzle, Action<Bullet> hitCallback)
        {
            base.Init(muzzle, hitCallback);

            _ricochetCounter = 0;
        }

        protected override bool OnHit(Collision other)
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable != null) // Player and Enemies
            {
                damageable.ApplyDamage(_damage);
                return true;
            }

            Vector3 normal = other.contacts[0].normal;
            Vector3 reflectedVector = Vector3.Reflect(transform.forward, normal);
            transform.forward = reflectedVector;
            
            _ricochetCounter++;
            return _ricochetCounter > _maxRicochetsCount;
        }
    }
}