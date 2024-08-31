using System;
using UnityEngine;
using UnityEngine.AI;

namespace Dajjsand.Views.Enemies.Base
{
    public abstract class EnemyMovementComponent : MonoBehaviour
    {
        [SerializeField] protected Transform _rotatingPart;
        [SerializeField] protected NavMeshAgent _agent;

        public bool CanMove { get; set; }

        protected Player.Player _target;

        public virtual void Init(Player.Player player)
        {
            _target = player;
        }

        private void Update()
        {
            if (!CanMove)
            {
                _agent.destination = _agent.transform.position;
                return;
            }

            Move();
        }

        protected abstract void Move();
    }
}