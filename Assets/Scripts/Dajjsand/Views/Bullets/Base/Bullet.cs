using System;
using Dajjsand.Utils.Types;
using Dajjsand.Views.Base;
using UnityEngine;

namespace Dajjsand.Views.Bullets.Base
{
    public class Bullet : MonoBehaviour
    {
        [field: SerializeField] public BulletType Type { get; private set; }
        [SerializeField] private float _speed = 1f;
        [SerializeField] protected int _damage = 1;

        private Action<Bullet> _toDestroyCallback;

        public virtual void Init(Transform muzzle, Action<Bullet> hitCallback)
        {
            transform.position = muzzle.position;
            transform.rotation = muzzle.rotation;

            _toDestroyCallback = hitCallback;
        }

        private void FixedUpdate()
        {
            transform.position += transform.forward * _speed;
        }

        protected virtual bool OnHit(Collision other)
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable != null) // Player and Enemies
                damageable.ApplyDamage(_damage);

            return true;
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.LogError(other.gameObject.name);
            bool isDestroy = OnHit(other);
            if (isDestroy)
                _toDestroyCallback?.Invoke(this);
        }
    }
}