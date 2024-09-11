using System;
using System.Collections;
using System.Collections.Generic;
using Dajjsand.Factories.Interfaces;
using Dajjsand.Utils;
using Dajjsand.Utils.Types;
using Dajjsand.Views.Bullets;
using Dajjsand.Views.Bullets.Strategies;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;
using Object = UnityEngine.Object;

namespace Dajjsand.Factories
{
    public class BulletFactory : IBulletFactory
    {
        private DiContainer _diContainer;
        private GameplayObjectsContainer _gameplayObjectsContainer;

        private Bullet _bulletPrefab;
        private ObjectPool<Bullet> _bulletsPool;

        public BulletFactory(DiContainer diContainer, GameplayObjectsContainer gameplayObjectsContainer)
        {
            _diContainer = diContainer;
            _gameplayObjectsContainer = gameplayObjectsContainer;
        }

        public IEnumerator LoadResources()
        {
            yield return _bulletPrefab = Resources.Load<Bullet>("Views/Bullets/Bullet");

            _bulletsPool = new(
                () => _diContainer.InstantiatePrefabForComponent<Bullet>(
                    _bulletPrefab.gameObject, _gameplayObjectsContainer.BulletsContainer),
                bullet => bullet.gameObject.SetActive(true),
                bullet => bullet.gameObject.SetActive(false),
                bullet => Object.Destroy(bullet.gameObject));
        }

        public Bullet InstantiateBullet(BulletEffectType[] bulletEffectTypes)
        {
            var bullet = _bulletsPool.Get();
            bullet.SetStrategies(StrategiesResolver(bulletEffectTypes));
            return bullet;
        }

        private IBulletStrategy[] StrategiesResolver(BulletEffectType[] bulletEffectTypes)
        {
            List<IBulletStrategy> bulletStrategies = new();
            foreach (BulletEffectType type in bulletEffectTypes)
                bulletStrategies.Add(StrategyResolver(type));

            return bulletStrategies.ToArray();
        }

        private IBulletStrategy StrategyResolver(BulletEffectType bulletEffectType)
        {
            switch (bulletEffectType)
            {
                case BulletEffectType.Instant:
                    return new InstantBulletStrategy();
                case BulletEffectType.Ricochet3:
                    return new RicochetBulletStrategy();
                case BulletEffectType.Poison:
                    return new PoisonBulletStrategy();
                default:
                    throw new ArgumentOutOfRangeException(nameof(bulletEffectType), bulletEffectType, null);
            }
        }
    }
}