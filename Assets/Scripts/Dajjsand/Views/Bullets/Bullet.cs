using System;
using UnityEngine;

namespace Dajjsand.Views.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] protected int _damage = 1;

        private Action<Bullet> _hitCallback;
        private IBulletStrategy _currentStrategy;

        public void Init(Transform muzzle, Action<Bullet> hitCallback)
        {
            _hitCallback = hitCallback;

            transform.position = muzzle.position;
            transform.rotation = muzzle.rotation;
        }

        public void SetStrategy(IBulletStrategy strategy)
        {
            _currentStrategy = strategy;
            _currentStrategy.Init(transform, _speed, _damage);
        }

        private void FixedUpdate()
        {
            _currentStrategy.Move();
        }

        private void OnCollisionEnter(Collision other)
        {
            bool isDestroy = _currentStrategy.OnHit(other);
            if (isDestroy)
                _hitCallback?.Invoke(this);
        }
    }
}