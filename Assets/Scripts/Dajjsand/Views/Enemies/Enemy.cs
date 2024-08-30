﻿using System;
using Dajjsand.Utils;
using Dajjsand.Views.Guns;
using UnityEngine;

namespace Dajjsand.Views.Enemies
{
    public class Enemy : MonoBehaviour
    {
        public event Action<Enemy> Dead;

        [SerializeField] private EnemyAttackComponent _attack;
        [SerializeField] private EnemyMovementComponent _movement;
        [SerializeField] private EnemyHealthComponent _health;
        [SerializeField] private Transform _bodyCenter;
        [SerializeField] private LayerMask _layerMask;
        [field: SerializeField] public int ContactDamage { get; private set; }

        private Player.Player _target;

        public Vector3 BodyPos => _bodyCenter.position;
        public bool IsDead => _health.IsDead;

        public void Init(Player.Player player, Gun gun)
        {
            _target = player;

            _health.Init();
            _attack.Init(gun, player, _bodyCenter);
            _movement.Init(player);

            _health.Dead += Health_Dead;
        }

        private void Update()
        {
            Vector3 checkVector = _target.BodyCenter.position - _bodyCenter.position;
            float range = checkVector.magnitude;
            Ray ray = new Ray(_bodyCenter.position, checkVector.normalized);
            bool isHitArena = Physics.SphereCast(ray, 0.5f, out RaycastHit hit, range, _layerMask);

            bool isAttack = !isHitArena && range <= _attack.AttackRange;
            UpdateBehaviorState(isAttack ? BehaviorState.CanAttack : BehaviorState.CanMove);
        }

        private void UpdateBehaviorState(BehaviorState newBehaviorState)
        {
            _attack.CanAttack = newBehaviorState == BehaviorState.CanAttack;
            _movement.CanMove = newBehaviorState == BehaviorState.CanMove;
        }

        private void Health_Dead()
        {
            UpdateBehaviorState(BehaviorState.NothingCanDo);

            Dead?.Invoke(this);
        }
    }
}