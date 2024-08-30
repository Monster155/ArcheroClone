using System;
using UnityEngine;

namespace Dajjsand.Views.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private int _damage = 1;

        private Action<Bullet> _hitCallback;

        public void Init(Transform muzzle, Action<Bullet> hitCallback)
        {
            transform.position = muzzle.position;
            transform.rotation = muzzle.rotation;

            _hitCallback = hitCallback;
        }

        private void FixedUpdate()
        {
            transform.position += transform.forward * _speed;
        }

        public int GetDamage()
        {
            _hitCallback?.Invoke(this);
            return _damage;
        }
    }
}