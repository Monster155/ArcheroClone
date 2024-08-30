using Dajjsand.Controllers;
using Dajjsand.Utils.LevelProgressionStates.Interfaces;
using Zenject;

namespace Dajjsand.Utils.LevelProgressionStates
{
    public class FinishState : ILevelProgressionState
    {
        private GameplayObjectsContainer _gameplayObjectsContainer;

        private LevelProgressionController _controller;

        private bool _doOnce;

        [Inject]
        private void Construct(GameplayObjectsContainer gameplayObjectsContainer)
        {
            _gameplayObjectsContainer = gameplayObjectsContainer;
        }

        public void SetContext(LevelProgressionController controller)
        {
            _controller = controller;
            _doOnce = false;
        }

        public void UpdateState()
        {
            if (_doOnce)
                return;

            _doOnce = true;
            _gameplayObjectsContainer.GameWinScreen.Show();
        }
    }
}