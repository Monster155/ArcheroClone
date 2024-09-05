using System.Collections;
using System.Collections.Generic;
using Dajjsand.Factories.Interfaces;
using Dajjsand.Utils.Types;
using Dajjsand.Views.Bullets;
using Dajjsand.Views.Bullets.Base;
using Dajjsand.Views.Enemies;
using UnityEngine;
using Zenject;

namespace Dajjsand.Factories
{
    public class BulletFactory : IBulletFactory
    {
        private DiContainer _diContainer;
        private Dictionary<BulletType, Bullet> _bulletsPrefabs = new Dictionary<BulletType, Bullet>();

        public BulletFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public IEnumerator LoadResources()
        {
            _bulletsPrefabs.Clear();

            Bullet[] bullets;
            yield return bullets = Resources.LoadAll<Bullet>("Views/Bullets");

            foreach (Bullet bullet in bullets)
                _bulletsPrefabs.Add(bullet.Type, bullet);
        }

        public Bullet InstantiateBullet(BulletType type, Transform container)
        {
            var bullet = _diContainer.InstantiatePrefabForComponent<Bullet>(
                _bulletsPrefabs[type].gameObject, container);
            return bullet;
        }
    }
}