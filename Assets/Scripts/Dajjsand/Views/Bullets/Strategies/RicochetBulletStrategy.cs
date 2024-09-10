using System;
using Dajjsand.Views.Base;
using UnityEngine;

namespace Dajjsand.Views.Bullets.Strategies
{
    public class RicochetBulletStrategy : IBulletStrategy
    {
        private const int MaxRicochetsCount = 3;

        private Transform _selfTransform;
        private float _speed;
        private int _damage;

        private int _ricochetCounter;

        public void Init(Transform selfTransform, float speed, int damage)
        {
            _selfTransform = selfTransform;
            _speed = speed;
            _damage = damage;

            _ricochetCounter = 0;
        }

        public void Move()
        {
            _selfTransform.position += _selfTransform.forward * _speed;
        }

        public bool OnHit(Collision other)
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable != null) // Player and Enemies
            {
                damageable.ApplyDamage(_damage);
                return true;
            }

            Vector3 normal = other.contacts[0].normal;
            Vector3 reflectedVector = Vector3.Reflect(_selfTransform.forward, normal);
            _selfTransform.forward = reflectedVector;

            _ricochetCounter++;
            return _ricochetCounter > MaxRicochetsCount;
        }
    }
}