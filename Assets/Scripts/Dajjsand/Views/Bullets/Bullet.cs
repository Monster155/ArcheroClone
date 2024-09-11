using System;
using UnityEngine;

namespace Dajjsand.Views.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;

        private Action<Bullet> _hitCallback;
        private IBulletStrategy[] _strategies;

        public void SetStrategies(IBulletStrategy[] strategies)
        {
            _strategies = strategies;
        }

        public void Init(Transform muzzle, Action<Bullet> hitCallback)
        {
            _hitCallback = hitCallback;

            transform.position = muzzle.position;
            transform.rotation = muzzle.rotation;
        }

        private void FixedUpdate()
        {
            foreach (IBulletStrategy strategy in _strategies)
                strategy.UpdateMovement(transform);

            transform.position += transform.forward * _speed;
        }

        private void OnCollisionEnter(Collision other)
        {
            bool isTotalDestroy = true;
            
            foreach (IBulletStrategy strategy in _strategies)
            {
                if (!strategy.OnHit(other))
                    isTotalDestroy = false;
            }
            
            if (isTotalDestroy)
                _hitCallback?.Invoke(this);
        }
    }
}