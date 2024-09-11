using System;
using System.Collections;
using Dajjsand.Controllers.Interfaces;
using Dajjsand.Utils.Types;
using UnityEngine;
using Zenject;

namespace Dajjsand.Views.Guns.Base
{
    public abstract class Gun : MonoBehaviour
    {
        [field: SerializeField] public GunType Type { get; private set; }
        [SerializeField] protected BulletEffectType[] _bulletEffectTypes;
        [field: SerializeField] public Transform Muzzle { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
        [SerializeField] protected float _reloadingTime = 3f;

        protected IBulletsController _bulletsController;

        protected bool _canShoot = true;

        [Inject]
        private void Construct(IBulletsController bulletsController)
        {
            _bulletsController = bulletsController;
        }

        public void Shoot()
        {
            if (!_canShoot)
                return;

            CreateBullets();
        }

        protected abstract void CreateBullets();

        protected void StartReloading(float timer, Action reloadedCallback)
        {
            _canShoot = false;

            StartCoroutine(ReloadingCoroutine(timer, reloadedCallback));
        }

        protected IEnumerator ReloadingCoroutine(float timer, Action reloadedCallback)
        {
            yield return new WaitForSeconds(timer);

            _canShoot = true;

            reloadedCallback?.Invoke();
        }
    }
}