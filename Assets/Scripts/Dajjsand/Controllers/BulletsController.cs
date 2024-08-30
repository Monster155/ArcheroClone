using System.Collections.Generic;
using Dajjsand.Controllers.Interfaces;
using Dajjsand.Factories.Interfaces;
using Dajjsand.Utils;
using Dajjsand.Views.Bullets;
using UnityEngine;
using Zenject;

namespace Dajjsand.Controllers
{
    public class BulletsController : IBulletsController
    {
        private IBulletFactory _bulletFactory;
        private GameplayObjectsContainer _gameplayObjectsContainer;

        private List<Bullet> _bullets;

        [Inject]
        private void Construct(IBulletFactory bulletFactory, GameplayObjectsContainer gameplayObjectsContainer)
        {
            _bulletFactory = bulletFactory;
            _gameplayObjectsContainer = gameplayObjectsContainer;
        }

        public void Init()
        {
            _bullets = new List<Bullet>();
        }

        public void ClearAllBullets()
        {
            foreach (Bullet bullet in _bullets)
            {
                bullet.gameObject.SetActive(false);
                Object.Destroy(bullet.gameObject);
            }

            _bullets.Clear();
        }

        public void CreateBullet(Transform muzzle)
        {
            Bullet bullet = _bulletFactory.InstantiateBullet(_gameplayObjectsContainer.BulletsContainer);
            bullet.Init(muzzle, OnBulletHit);
            _bullets.Add(bullet);
        }

        private void OnBulletHit(Bullet bullet)
        {
            _bullets.Remove(bullet);
            Object.Destroy(bullet.gameObject);
        }
    }
}