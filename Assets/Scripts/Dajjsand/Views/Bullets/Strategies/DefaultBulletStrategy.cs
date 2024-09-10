using System;
using Dajjsand.Views.Base;
using UnityEngine;

namespace Dajjsand.Views.Bullets.Strategies
{
    public class DefaultBulletStrategy : IBulletStrategy
    {
        private Transform _selfTransform;
        private float _speed;
        private int _damage;

        public void Init(Transform selfTransform, float speed, int damage)
        {
            _selfTransform = selfTransform;
            _speed = speed;
            _damage = damage;
        }
        
        public void Move()
        {
            _selfTransform.position += _selfTransform.forward * _speed;
        }

        public bool OnHit(Collision other)
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable != null) // Player and Enemies
                damageable.ApplyDamage(_damage);

            return true;
        }
    }
}