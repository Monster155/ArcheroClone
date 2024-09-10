using System;
using System.Collections;
using System.Collections.Generic;
using Dajjsand.Factories.Interfaces;
using Dajjsand.Utils.Types;
using Dajjsand.Views.Bullets;
using Dajjsand.Views.Bullets.Strategies;
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

        public Bullet InstantiateBullet(BulletType type, Transform container)
        {
            var bullet = _diContainer.InstantiatePrefabForComponent<Bullet>(
                _bulletPrefab.gameObject, container);
            bullet.SetStrategy(StrategyResolver(type));
            return bullet;
        }
        
        private IBulletStrategy StrategyResolver(BulletType type)
        {
            switch (type)
            {
                case BulletType.Default:
                    return new DefaultBulletStrategy();
                case BulletType.Ricochet3:
                    return new RicochetBulletStrategy();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}