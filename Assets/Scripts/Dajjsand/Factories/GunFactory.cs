using System.Collections;
using System.Collections.Generic;
using Dajjsand.Factories.Interfaces;
using Dajjsand.Utils.Types;
using Dajjsand.Views.Guns;
using Dajjsand.Views.Guns.Base;
using UnityEngine;
using Zenject;

namespace Dajjsand.Factories
{
    public class GunFactory : IGunFactory
    {
        private DiContainer _diContainer;
        private Dictionary<GunType, Gun> _gunsPrefabs = new Dictionary<GunType, Gun>();

        public GunFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public IEnumerator LoadResources()
        {
            _gunsPrefabs.Clear();
            
            Gun[] guns;
            yield return guns = Resources.LoadAll<Gun>("Views/Guns");

            foreach (Gun gun in guns)
                _gunsPrefabs.Add(gun.Type, gun);
        }

        public Gun InstantiateGun(GunType gunType, Transform container)
        {
            Gun gun = _diContainer.InstantiatePrefabForComponent<Gun>(
                _gunsPrefabs[gunType].gameObject, container);
            return gun;
        }
    }
}