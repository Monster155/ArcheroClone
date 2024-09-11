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
        private Dictionary<int, ObjectPool<Bullet>> _masterPool = new();

        public BulletFactory(DiContainer diContainer, GameplayObjectsContainer gameplayObjectsContainer)
        {
            _diContainer = diContainer;
            _gameplayObjectsContainer = gameplayObjectsContainer;
        }

        public IEnumerator LoadResources()
        {
            yield return _bulletPrefab = Resources.Load<Bullet>("Views/Bullets/Bullet");
        }

        public Bullet InstantiateBullet(BulletEffectType[] bulletEffectTypes)
        {
            int hash = EffectsToHash(bulletEffectTypes);
            bool isPoolAvailable = _masterPool.TryGetValue(hash, out var pool);
            if (!isPoolAvailable)
            {
                pool = new(
                    () =>
                    {
                        var b = _diContainer.InstantiatePrefabForComponent<Bullet>(
                            _bulletPrefab.gameObject, _gameplayObjectsContainer.BulletsContainer);
                        b.SetStrategies(StrategiesResolver(bulletEffectTypes));
                        return b;
                    },
                    bullet => bullet.gameObject.SetActive(true),
                    bullet => bullet.gameObject.SetActive(false),
                    bullet => Object.Destroy(bullet.gameObject));

                _masterPool.Add(hash, pool);
            }

            var bullet = pool.Get();
            return bullet;
        }

        private int EffectsToHash(BulletEffectType[] bulletEffectTypes)
        {
            int hash = 0;
            foreach (int effect in bulletEffectTypes)
                hash = hash | 1 << effect;

            return hash;
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