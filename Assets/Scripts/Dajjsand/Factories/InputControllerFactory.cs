using System;
using System.Collections;
using Dajjsand.Factories.Interfaces;
using Dajjsand.Views.InputControllers;
using UnityEngine;
using Zenject;

namespace Dajjsand.Factories
{
    public class InputControllerFactory : IInputControllerFactory
    {
        private DiContainer _diContainer;
        private MobileInputController _inputControllerPrefab;

        public InputControllerFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public IEnumerator LoadResources()
        {
            yield return _inputControllerPrefab = Resources.Load<MobileInputController>("Views/InputControllers/InputController");
        }

        public MobileInputController InstantiateInputController(Transform parent)
        {
            var inputController = _diContainer.InstantiatePrefabForComponent<MobileInputController>(_inputControllerPrefab.gameObject, parent);
            return inputController;
        }
    }
}