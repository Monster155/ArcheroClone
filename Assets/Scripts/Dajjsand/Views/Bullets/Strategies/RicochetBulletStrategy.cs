using System;
using Dajjsand.Views.Base;
using UnityEngine;

namespace Dajjsand.Views.Bullets.Strategies
{
    public class RicochetBulletStrategy : IBulletStrategy
    {
        private const int MaxRicochetsCount = 3;
        private int _ricochetCounter;

        private bool _isChangesApplied = true;
        private Vector3 _normal;

        public void UpdateMovement(Transform selfTransform)
        {
            if (_isChangesApplied)
                return;

            Vector3 reflectedVector = Vector3.Reflect(selfTransform.forward, _normal);
            selfTransform.forward = reflectedVector;
            
            _isChangesApplied = true;
        }

        public bool OnHit(Collision other)
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable != null) // Player and Enemies
                return true;

            _normal = other.contacts[0].normal;
            _isChangesApplied = false;

            _ricochetCounter++;
            return _ricochetCounter > MaxRicochetsCount;
        }
    }
}