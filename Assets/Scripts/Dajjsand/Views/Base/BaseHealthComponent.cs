using System;
using System.Collections.Generic;
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

        private List<PeriodicDamage> _periodicDamages;

        public bool IsDead { get; private set; }

        public void Init(HealthBarsController healthBarsController)
        {
            _healthBarsController = healthBarsController;
            _hpBar = _healthBarsController.GetHealthBar();

            _periodicDamages = new();

            IsDead = false;
            _currentHP = _maxHP;
        }

        private void Update()
        {
            _hpBar.UpdatePos(_hpBarTarget);
            UpdatePeriodicDamages();
        }

        private void UpdatePeriodicDamages()
        {
            _periodicDamages.RemoveAll(perDam => perDam.RepeatsCount == 0);

            foreach (PeriodicDamage periodicDamage in _periodicDamages)
            {
                periodicDamage.CurrentTimer -= Time.deltaTime;
                if (periodicDamage.CurrentTimer <= 0)
                {
                    ApplyDamage(periodicDamage.Damage);
                    periodicDamage.RepeatsCount--;
                    periodicDamage.CurrentTimer += periodicDamage.MaxTimer; // if make it "=" - we can lose some seconds
                }
            }
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

        public void ApplyPeriodicDamage(int periodicDamage, int repeatsCount, float damageOnceTimer)
        {
            _periodicDamages.Add(new PeriodicDamage()
            {
                Damage = periodicDamage,
                RepeatsCount = repeatsCount,
                CurrentTimer = damageOnceTimer,
                MaxTimer = damageOnceTimer,
            });
        }

        private void Dead()
        {
            _healthBarsController.ReleaseHealthBar(_hpBar);

            IsDead = true;

            OnDead?.Invoke();
        }

        private class PeriodicDamage
        {
            public int Damage;
            public int RepeatsCount;
            public float CurrentTimer;
            public float MaxTimer;
        }
    }
}