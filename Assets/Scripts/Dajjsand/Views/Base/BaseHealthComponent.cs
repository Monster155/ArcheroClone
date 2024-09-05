using System;
using Dajjsand.Views.Bullets.Base;
using Dajjsand.Views.Enemies;
using UnityEngine;

namespace Dajjsand.Views.Base
{
    public class BaseHealthComponent : MonoBehaviour, IDamageable
    {
        public event Action Dead;

        [SerializeField] private int _maxHP = 10;

        private int _currentHP;

        public bool IsDead { get; private set; }

        public void Init()
        {
            IsDead = false;
            _currentHP = _maxHP;
        }

        public void ApplyDamage(int damage)
        {
            if (IsDead)
                return;

            _currentHP -= damage;
            Debug.Log(name + " = Got damage: " + damage + " Current HP: " + _currentHP);

            if (_currentHP <= 0)
            {
                IsDead = true;

                Dead?.Invoke();
            }
        }
    }
}