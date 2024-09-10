using System;
using Dajjsand.Views.Enemies;
using Dajjsand.Views.HealthBars;
using UnityEngine;

namespace Dajjsand.Views.Base
{
    public class BaseHealthComponent : MonoBehaviour, IDamageable
    {
        public event Action OnDead;

        [SerializeField] private Transform _hpBarTarget;
        [SerializeField] private int _maxHP = 10;

        private HealthBarsController _healthBarsController;
        private HealthBar _hpBar;
        private int _currentHP;

        public bool IsDead { get; private set; }

        public void Init(HealthBarsController healthBarsController)
        {
            _healthBarsController = healthBarsController;
            _hpBar = _healthBarsController.GetHealthBar();

            IsDead = false;
            _currentHP = _maxHP;
        }

        private void Update()
        {
            _hpBar.UpdatePos(_hpBarTarget);
        }

        public void ApplyDamage(int damage)
        {
            if (IsDead)
                return;

            _currentHP -= damage;

            if (_currentHP <= 0)
            {
                _currentHP = 0;
                Dead();
            }

            _hpBar.UpdateValue((float)_currentHP / _maxHP);
        }

        private void Dead()
        {
            _healthBarsController.ReleaseHealthBar(_hpBar);

            IsDead = true;

            OnDead?.Invoke();
        }
    }
}