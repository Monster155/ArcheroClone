using System.Collections;
using Dajjsand.Utils.Types;
using Dajjsand.Views.Bullets;
using UnityEngine;

namespace Dajjsand.Factories.Interfaces
{
    public interface IBulletFactory
    {
        IEnumerator LoadResources();
        Bullet InstantiateBullet(BulletEffectType[] bulletEffectTypes);
    }
}