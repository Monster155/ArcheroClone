using System.Collections;
using Dajjsand.Factories.Interfaces;
using Dajjsand.Views.Guns;
using Dajjsand.Views.Guns.Base;
using UnityEngine;
using Zenject;

namespace Dajjsand.Factories
{
    public class GunFactory : IGunFactory
    {
        private DiContainer _diContainer;
        private Gun[] _gunsPrefabs;

        public GunFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public IEnumerator LoadResources()
        {
            yield return _gunsPrefabs = Resources.LoadAll<Gun>("Views/Guns");
        }

        public Gun InstantiateRandomGun(Transform container)
        {
            int randomIndex = Random.Range(0, _gunsPrefabs.Length);
            Gun gun = _diContainer.InstantiatePrefabForComponent<Gun>(
                _gunsPrefabs[randomIndex].gameObject, container);
            return gun;
        }
    }
}