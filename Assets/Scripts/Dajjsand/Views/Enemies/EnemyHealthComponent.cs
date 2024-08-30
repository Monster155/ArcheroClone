using System;
using Dajjsand.Views.Bullets;
using UnityEngine;

namespace Dajjsand.Views.Enemies
{
    public class EnemyHealthComponent : MonoBehaviour
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

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.tag.Equals("Player"))
            {
                ApplyDamage(other.transform.GetComponent<Player.Player>().ContactDamage);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag.Equals("Bullet"))
            {
                ApplyDamage(other.transform.GetComponent<Bullet>().GetDamage());
            }
        }
    }
}