using Dajjsand.Utils.Types;
using Dajjsand.Views.Guns;
using UnityEngine;

namespace Dajjsand.Controllers.Interfaces
{
    public interface IBulletsController
    {
        void Init();
        void ClearAllBullets();
        void CreateBullet(BulletEffectType[] bulletEffectTypes, Transform muzzle);
    }
}