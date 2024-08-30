using Dajjsand.Controllers;
using Dajjsand.Controllers.Interfaces;
using Dajjsand.Utils.LevelProgressionStates.Interfaces;
using Zenject;

namespace Dajjsand.Utils.LevelProgressionStates
{
    public class KillAllEnemiesState : ILevelProgressionState
    {
        private IEnemiesController _enemiesController;
        private IPlayerController _playerController;
        private IBulletsController _bulletsController;

        private LevelProgressionController _controller;

        [Inject]
        private void Construct(IEnemiesController enemiesController,
            IPlayerController playerController,
            IBulletsController bulletsController)
        {
            _enemiesController = enemiesController;
            _playerController = playerController;
            _bulletsController = bulletsController;
        }

        public void SetContext(LevelProgressionController controller)
        {
            _controller = controller;
            _enemiesController.AllEnemiesDead += EnemiesController_OnAllEnemiesDead;
            _playerController.PlayerDead += PlayerController_PlayerDead;
        }

        public void UpdateState()
        {
        }

        private void UnsubscribeEvents()
        {
            _enemiesController.AllEnemiesDead -= EnemiesController_OnAllEnemiesDead;
            _playerController.PlayerDead -= PlayerController_PlayerDead;
        }

        private void PlayerController_PlayerDead()
        {
            _bulletsController.ClearAllBullets();
            UnsubscribeEvents();
            _controller.ChangeState<PlayerDeadState>();
        }

        private void EnemiesController_OnAllEnemiesDead()
        {
            _bulletsController.ClearAllBullets();
            UnsubscribeEvents();
            _controller.ChangeState<EscapeRoomState>();
        }
    }
}