using System.Collections;
using Dajjsand.Utils.Types;
using Dajjsand.Views.Bullets;
using Dajjsand.Views.Bullets.Base;
using UnityEngine;

namespace Dajjsand.Factories.Interfaces
{
    public interface IBulletFactory
    {
        IEnumerator LoadResources();
        Bullet InstantiateBullet(BulletType type, Transform container);
    }
}