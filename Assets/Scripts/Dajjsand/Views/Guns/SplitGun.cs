using Dajjsand.Views.Guns.Base;
using UnityEngine;

namespace Dajjsand.Views.Guns
{
    public class SplitGun : Gun
    {
        [SerializeField] private Transform _secondMuzzle;
        [SerializeField] private Transform _thirdMuzzle;

        protected override void CreateBullets()
        {
            _bulletsController.CreateBullet(_bulletEffectTypes, Muzzle);
            _bulletsController.CreateBullet(_bulletEffectTypes, _secondMuzzle);
            _bulletsController.CreateBullet(_bulletEffectTypes, _thirdMuzzle);
            
            StartReloading(_reloadingTime, null);
        }
    }
}