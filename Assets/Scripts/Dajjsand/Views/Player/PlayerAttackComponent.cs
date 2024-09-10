using System.Collections.Generic;
using Dajjsand.Controllers.Interfaces;
using Dajjsand.Views.Base;
using Dajjsand.Views.Enemies;
using Dajjsand.Views.Guns;
using UnityEngine;
using Zenject;

namespace Dajjsand.Views.Player
{
    public class PlayerAttackComponent : AutoAttackComponent
    {
        [SerializeField] private float _distanceDiffToNewTarget = 1f;

        private IEnemiesController _enemiesController;

        [Inject]
        private void Construct(IEnemiesController enemiesController)
        {
            _enemiesController = enemiesController;
        }

        protected override void Attacking()
        {
            List<Enemy> enemies = _enemiesController.Enemies;
            Enemy closestEnemy = null;
            float closestDistance = 0;

            foreach (Enemy enemy in enemies)
            {
                if (enemy.IsDead)
                    continue;

                float distance = Vector3.Distance(enemy.BodyPos, _bodyCenter.position);
                if (distance > _gun.AttackRange)
                    continue;

                if (closestEnemy != null && distance > closestDistance)
                    continue;

                Vector3 checkVector = enemy.BodyPos - _bodyCenter.position;
                bool isHitArena = Physics.Raycast(
                    _gun.Muzzle.position,
                    checkVector.normalized,
                    out RaycastHit hit,
                    checkVector.magnitude,
                    LayerMask.GetMask("Arena"));

                if (isHitArena)
                    continue;

                closestDistance = distance;
                closestEnemy = enemy;
            }

            if (closestEnemy == null)
                _targetBodyCenter = null;
            else if (_targetBodyCenter == null)
                _targetBodyCenter = closestEnemy.transform;
            else
            {
                float distanceToTarget = Vector3.Distance(_targetBodyCenter.position, _bodyCenter.position);
                float distanceToClosest = Vector3.Distance(closestEnemy.BodyPos, _bodyCenter.position);

                if (distanceToTarget - distanceToClosest > _distanceDiffToNewTarget)
                    _targetBodyCenter = closestEnemy.transform;
            }

            base.Attacking();
        }
    }
}