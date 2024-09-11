using System;
using System.Collections;
using Dajjsand.Views.Guns.Base;
using UnityEngine;

namespace Dajjsand.Views.Guns
{
    public class RifleGun : Gun
    {
        [SerializeField] private int _magazineSize = 30;
        [SerializeField] private int _bulletsCountInRow = 5;
        [SerializeField] private float _rowReloading = 1.5f;
        [SerializeField] private float _bulletsInRowReloading = 0.1f;

        private int _currentMagazineSize;

        private void Start()
        {
            ResetMagazine();
        }

        private void ResetMagazine() =>
            _currentMagazineSize = _magazineSize;

        protected override void CreateBullets()
        {
            int bulletsToShoot = Math.Min(_currentMagazineSize, _bulletsCountInRow);
            StartCoroutine(ShootBulletsCoroutine(bulletsToShoot));
            _currentMagazineSize -= bulletsToShoot;
        }
        
        private IEnumerator ShootBulletsCoroutine(int bulletsInRow)
        {
            _canShoot = false;

            for (int i = 1; i < bulletsInRow; i++)
            {
                _bulletsController.CreateBullet(_bulletEffectTypes, Muzzle);
                yield return new WaitForSeconds(_bulletsInRowReloading);
            }
            _bulletsController.CreateBullet(_bulletEffectTypes, Muzzle);

            if (_currentMagazineSize > 0)
                StartReloading(_rowReloading, null);
            else
                StartReloading(_reloadingTime, ResetMagazine);
        }
    }
}