using Dajjsand.Controllers;
using Dajjsand.Controllers.Interfaces;
using Dajjsand.Utils.LevelProgressionStates.Interfaces;
using Zenject;

namespace Dajjsand.Utils.LevelProgressionStates
{
    public class FinishState : ILevelProgressionState
    {
        private GameplayObjectsContainer _gameplayObjectsContainer;
        private IPlayerController _playerController;

        private LevelProgressionController _controller;

        private bool _doOnce;

        [Inject]
        private void Construct(GameplayObjectsContainer gameplayObjectsContainer,
            IPlayerController playerController)
        {
            _gameplayObjectsContainer = gameplayObjectsContainer;
            _playerController = playerController;
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
            _playerController.StopPlayer();
            _gameplayObjectsContainer.GameWinScreen.Show();
        }
    }
}