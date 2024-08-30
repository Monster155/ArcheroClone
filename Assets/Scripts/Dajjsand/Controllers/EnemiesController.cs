using System;
using System.Collections.Generic;
using Dajjsand.Controllers.Interfaces;
using Dajjsand.Factories.Interfaces;
using Dajjsand.Views.Enemies;
using Dajjsand.Views.Guns;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Dajjsand.Controllers
{
    public class EnemiesController : IEnemiesController
    {
        public event Action AllEnemiesDead;

        private IEnemyFactory _enemyFactory;
        private IPlayerController _playerController;
        private IGunFactory _gunFactory;

        public List<Enemy> Enemies { get; private set; }
        private int _deadEnemiesCount;

        [Inject]
        private void Construct(IEnemyFactory enemyFactory, IPlayerController playerController,
            IGunFactory gunFactory)
        {
            _enemyFactory = enemyFactory;
            _playerController = playerController;
            _gunFactory = gunFactory;
        }

        public void Init(Transform[] spawnPoints, Transform container)
        {
            Enemies = new List<Enemy>();
            _deadEnemiesCount = 0;

            foreach (Transform spawnPoint in spawnPoints)
            {
                Gun gun = _gunFactory.InstantiateGun(null);

                Enemy enemy = _enemyFactory.InstantiateEnemy(container);
                enemy.Init(_playerController.Player, gun);
                enemy.Dead += Enemy_OnDead;
                enemy.transform.position = spawnPoint.position;
                enemy.gameObject.SetActive(false);

                Enemies.Add(enemy);
            }
        }

        private void Enemy_OnDead(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);

            // if needed change from "kill all" to "kill X enemies" - then move counting to Progression State
            _deadEnemiesCount++;
            if (_deadEnemiesCount == Enemies.Count)
            {
                AllEnemiesDead?.Invoke();
            }
        }

        public void Start()
        {
            foreach (Enemy enemy in Enemies)
                enemy.gameObject.SetActive(true);
        }
    }
}