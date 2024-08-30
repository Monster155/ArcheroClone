using System.Collections;
using Dajjsand.Views.Bullets;
using UnityEngine;

namespace Dajjsand.Factories.Interfaces
{
    public interface IBulletFactory
    {
        IEnumerator LoadResources();
        Bullet InstantiateBullet(Transform container);
    }
}