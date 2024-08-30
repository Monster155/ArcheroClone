using System.Collections;
using Dajjsand.Controllers.Interfaces;
using UnityEngine;
using Zenject;

namespace Dajjsand.Views.Guns
{
    public class Gun : MonoBehaviour
    {
        [field: SerializeField] public Transform Muzzle { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
        [SerializeField] private float _reloadingTime = 3f;

        private IBulletsController _bulletsController;

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
            _bulletsController.CreateBullet(Muzzle);
            StartCoroutine(ReloadingCoroutine());
        }

        private IEnumerator ReloadingCoroutine()
        {
            yield return new WaitForSeconds(_reloadingTime);

            _canShoot = true;
        }
    }
}