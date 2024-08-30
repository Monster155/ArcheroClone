using System.Collections;
using Dajjsand.Views.InputControllers;
using UnityEngine;

namespace Dajjsand.Factories.Interfaces
{
    public interface IInputControllerFactory
    {
        public IEnumerator LoadResources();
        public MobileInputController InstantiateInputController(Transform parent);
    }
}