using System.Collections;
using Dajjsand.Views.Guns;
using UnityEngine;

namespace Dajjsand.Factories.Interfaces
{
    public interface IGunFactory
    {
        IEnumerator LoadResources();
        Gun InstantiateGun(Transform container);
    }
}