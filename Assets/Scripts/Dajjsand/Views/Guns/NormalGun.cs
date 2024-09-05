using Dajjsand.Views.Guns.Base;
using UnityEngine;

namespace Dajjsand.Views.Guns
{
    public class NormalGun : Gun
    {
        protected override void CreateBullets()
        {
            _bulletsController.CreateBullet(_bulletType, Muzzle);
        }
    }
}