using System;
using Dajjsand.Controllers.Interfaces;
using Dajjsand.Utils.LevelProgressionStates;
using Dajjsand.Utils.LevelProgressionStates.Interfaces;
using UnityEngine;
using Zenject;

namespace Dajjsand.Controllers
{
    public class LevelProgressionController : ILevelProgressionController, ITickable
    {
        private DiContainer _diContainer;

        private ILevelProgressionState _currentState;
        private bool _isInited;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Init()
        {
            ChangeState<StartState>();

            _isInited = true;
        }

        public void Tick()
        {
            if (!_isInited)
                return;

            _currentState.UpdateState();
        }

        public void ChangeState<T>() where T : ILevelProgressionState
        {
            ILevelProgressionState newState = _diContainer.Instantiate<T>();
            newState.SetContext(this);
            _currentState = newState;
        }
    }
}