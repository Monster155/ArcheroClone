using Dajjsand.Factories.Interfaces;
using Dajjsand.Services.InputServices.Interfaces;
using Dajjsand.Utils;
using Dajjsand.Views.InputControllers;

namespace Dajjsand.Services.InputServices
{
    public class MobileInputService : IInputService
    {
        public float Horizontal => _inputController.Horizontal;
        public float Vertical => _inputController.Vertical;

        private GameplayObjectsContainer _gameplayObjectsContainer;
        private IInputControllerFactory _inputControllerFactory;

        private MobileInputController _inputController;

        public MobileInputService(GameplayObjectsContainer gameplayObjectsContainer,
            IInputControllerFactory inputControllerFactory)
        {
            _gameplayObjectsContainer = gameplayObjectsContainer;
            _inputControllerFactory = inputControllerFactory;
        }

        public void Init()
        {
            _inputController = _inputControllerFactory.InstantiateInputController(_gameplayObjectsContainer.UICanvas.transform);
        }
    }
}