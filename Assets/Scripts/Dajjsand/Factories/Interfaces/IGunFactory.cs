using System.Collections;
using Dajjsand.Views.Guns;
using Dajjsand.Views.Guns.Base;
using UnityEngine;

namespace Dajjsand.Factories.Interfaces
{
    public interface IGunFactory
    {
        IEnumerator LoadResources();
        Gun InstantiateRandomGun(Transform container);
    }
}