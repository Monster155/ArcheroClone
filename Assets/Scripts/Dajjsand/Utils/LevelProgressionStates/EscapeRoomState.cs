using Dajjsand.Controllers;
using Dajjsand.Utils.LevelProgressionStates.Interfaces;
using Zenject;

namespace Dajjsand.Utils.LevelProgressionStates
{
    public class EscapeRoomState : ILevelProgressionState
    {
        private GameplayObjectsContainer _gameplayObjectsContainer;

        private LevelProgressionController _controller;

        [Inject]
        private void Construct(GameplayObjectsContainer gameplayObjectsContainer)
        {
            _gameplayObjectsContainer = gameplayObjectsContainer;
        }

        public void SetContext(LevelProgressionController controller)
        {
            _controller = controller;
            _gameplayObjectsContainer.EscapeRoomDoorHandler.PlayerCollide += EscapeRoomDoorHandler_PlayerCollide;
        }

        public void UpdateState()
        {
        }

        private void EscapeRoomDoorHandler_PlayerCollide()
        {
            _gameplayObjectsContainer.EscapeRoomDoorHandler.PlayerCollide -= EscapeRoomDoorHandler_PlayerCollide;

            _controller.ChangeState<FinishState>();
        }
    }
}