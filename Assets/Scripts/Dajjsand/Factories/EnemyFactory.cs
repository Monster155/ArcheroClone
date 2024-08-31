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
        private Enemy[] _enemiesPrefabs;

        public EnemyFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public IEnumerator LoadResources()
        {
            yield return _enemiesPrefabs = Resources.LoadAll<Enemy>("Views/Enemies");
        }

        public Enemy InstantiateRandomEnemy(Transform container)
        {
            int randomIndex = Random.Range(0, _enemiesPrefabs.Length);
            Enemy enemy = _diContainer.InstantiatePrefabForComponent<Enemy>(
                _enemiesPrefabs[randomIndex].gameObject, container);
            return enemy;
        }
    }
}