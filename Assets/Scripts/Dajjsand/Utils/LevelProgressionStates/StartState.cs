using Dajjsand.Controllers;
using Dajjsand.Controllers.Interfaces;
using Dajjsand.Utils.LevelProgressionStates.Interfaces;
using UnityEngine;
using Zenject;

namespace Dajjsand.Utils.LevelProgressionStates
{
    public class StartState : ILevelProgressionState
    {
        private IPlayerController _playerController;
        private IEnemiesController _enemiesController;

        private LevelProgressionController _controller;

        [Inject]
        private void Construct(IPlayerController playerController,
            IEnemiesController enemiesController)
        {
            _playerController = playerController;
            _enemiesController = enemiesController;
        }

        public void SetContext(LevelProgressionController controller)
        {
            _controller = controller;
        }

        public void UpdateState()
        {
            _playerController.Start();
            _enemiesController.Start();

            _controller.ChangeState<KillAllEnemiesState>();
        }
    }
}