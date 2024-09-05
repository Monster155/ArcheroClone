using System.Collections;
using Dajjsand.Utils.Types;
using Dajjsand.Views.Guns;
using Dajjsand.Views.Guns.Base;
using UnityEngine;

namespace Dajjsand.Factories.Interfaces
{
    public interface IGunFactory
    {
        IEnumerator LoadResources();
        Gun InstantiateGun(GunType gunType, Transform container);
    }
}