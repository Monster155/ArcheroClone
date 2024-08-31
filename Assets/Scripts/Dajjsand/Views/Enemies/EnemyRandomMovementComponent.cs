using System;
using Dajjsand.Views.Enemies.Base;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dajjsand.Views.Enemies
{
    public class EnemyRandomMovementComponent : EnemyMovementComponent
    {
        private Vector3 _destination;
        private float _timer;

        public override void Init(Player.Player player)
        {
            base.Init(player);
            GenerateValues();
        }

        private void GenerateValues()
        {
            _destination = new Vector3(
                Random.Range(-10, 10),
                Random.Range(-10, 10),
                Random.Range(-10, 10));

            _timer = Random.Range(1, 3);
        }

        protected override void Move()
        {
            _agent.destination = _destination;
            _timer -= Time.deltaTime;

            if (_agent.velocity.magnitude > 0)
                _rotatingPart.rotation = Quaternion.Euler(
                    0,
                    Quaternion.LookRotation(_agent.velocity).eulerAngles.y,
                    0);

            if (_timer <= 0)
                GenerateValues();
        }
    }
}