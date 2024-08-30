using System;
using System.Collections;
using Dajjsand.Controllers.Interfaces;
using Dajjsand.Factories.Interfaces;
using Dajjsand.Services.InputServices.Interfaces;
using Dajjsand.Utils;
using UnityEngine;
using Zenject;

namespace Dajjsand.Activators
{
    public class GameActivator : MonoBehaviour
    {
        private GameplayObjectsContainer _gameplayObjectsContainer;
        private IInputService _inputService;

        private IInputControllerFactory _inputControllerFactory;
        private IGunFactory _gunFactory;
        private IBulletFactory _bulletFactory;
        private IEnemyFactory _enemyFactory;
        private IPlayerFactory _playerFactory;

        private IEnemiesController _enemiesController;
        private IPlayerController _playerController;
        private IBulletsController _bulletsController;
        private ILevelProgressionController _levelProgressionController;

        [Inject]
        public void Construct(GameplayObjectsContainer gameplayObjectsContainer,
            IInputControllerFactory inputControllerFactory,
            IGunFactory gunFactory,
            IBulletFactory bulletFactory,
            IEnemyFactory enemyFactory,
            IPlayerFactory playerFactory,
            IInputService inputService,
            IEnemiesController enemiesController,
            IPlayerController playerController,
            IBulletsController bulletsController,
            ILevelProgressionController levelProgressionController)
        {
            _gameplayObjectsContainer = gameplayObjectsContainer;
            _inputControllerFactory = inputControllerFactory;

            _inputService = inputService;
            _gunFactory = gunFactory;
            _bulletFactory = bulletFactory;
            _enemyFactory = enemyFactory;
            _playerFactory = playerFactory;

            _enemiesController = enemiesController;
            _playerController = playerController;
            _bulletsController = bulletsController;
            _levelProgressionController = levelProgressionController;
        }

        private void Awake()
        {
            StartCoroutine(StartupCoroutine());
        }

        private IEnumerator StartupCoroutine()
        {
            _gameplayObjectsContainer.LoadingScreen.Init(true);

            //

            yield return _inputControllerFactory.LoadResources();
            yield return _gunFactory.LoadResources();
            yield return _bulletFactory.LoadResources();
            yield return _enemyFactory.LoadResources();
            yield return _playerFactory.LoadResources();

            _inputService.Init();

            _playerController.Init(_gameplayObjectsContainer.PlayerSpawnPoint);
            _enemiesController.Init(_gameplayObjectsContainer.EnemiesSpawnPoints, _gameplayObjectsContainer.EnemiesContainer);
            _bulletsController.Init();
            
            _levelProgressionController.Init();

            //

            _gameplayObjectsContainer.LoadingScreen.Hide();
        }
    }
}