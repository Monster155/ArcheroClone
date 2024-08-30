using System.Collections;
using Dajjsand.Factories.Interfaces;
using Dajjsand.Views.Enemies;
using UnityEngine;
using Zenject;

namespace Dajjsand.Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        private DiContainer _diContainer;
        private Enemy _enemyPrefab;

        public EnemyFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public IEnumerator LoadResources()
        {
            yield return _enemyPrefab = Resources.Load<Enemy>("Views/Enemies/Enemy");
        }

        public Enemy InstantiateEnemy(Transform container)
        {
            Enemy enemy = _diContainer.InstantiatePrefabForComponent<Enemy>(_enemyPrefab.gameObject, container);
            return enemy;
        }
    }
}