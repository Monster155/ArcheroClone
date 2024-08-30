using System.Collections;
using Dajjsand.Factories.Interfaces;
using Dajjsand.Views.Bullets;
using Dajjsand.Views.Enemies;
using UnityEngine;
using Zenject;

namespace Dajjsand.Factories
{
    public class BulletFactory : IBulletFactory
    {
        private DiContainer _diContainer;
        private Bullet _bulletPrefab;

        public BulletFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public IEnumerator LoadResources()
        {
            yield return _bulletPrefab = Resources.Load<Bullet>("Views/Bullets/Bullet");
        }

        public Bullet InstantiateBullet(Transform container)
        {
            var bullet = _diContainer.InstantiatePrefabForComponent<Bullet>(_bulletPrefab.gameObject, container);
            return bullet;
        }
    }
}