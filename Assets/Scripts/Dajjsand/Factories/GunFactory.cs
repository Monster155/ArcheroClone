using System.Collections;
using Dajjsand.Factories.Interfaces;
using Dajjsand.Views.Guns;
using UnityEngine;
using Zenject;

namespace Dajjsand.Factories
{
    public class GunFactory : IGunFactory
    {
        private DiContainer _diContainer;
        private Gun _gunPrefab;

        public GunFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public IEnumerator LoadResources()
        {
            yield return _gunPrefab = Resources.Load<Gun>("Views/Guns/Gun");
        }

        public Gun InstantiateGun(Transform container)
        {
            var gun = _diContainer.InstantiatePrefabForComponent<Gun>(_gunPrefab.gameObject, container);
            return gun;
        }
    }
}