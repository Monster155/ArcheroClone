using System.Collections;
using Dajjsand.Controllers.Interfaces;
using UnityEngine;
using Zenject;

namespace Dajjsand.Views.Guns.Base
{
    public abstract class Gun : MonoBehaviour
    {
        [field: SerializeField] public Transform Muzzle { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
        [SerializeField] private float _reloadingTime = 3f;

        protected IBulletsController _bulletsController;

        private bool _canShoot = true;

        [Inject]
        private void Construct(IBulletsController bulletsController)
        {
            _bulletsController = bulletsController;
        }

        public void Shoot()
        {
            if(!_canShoot)
                return;

            _canShoot = false;
            CreateBullets();
            StartCoroutine(ReloadingCoroutine());
        }

        protected abstract void CreateBullets();

        private IEnumerator ReloadingCoroutine()
        {
            yield return new WaitForSeconds(_reloadingTime);

            _canShoot = true;
        }
    }
}