using Dajjsand.Services.InputServices;
using Dajjsand.Utils;
using UnityEngine;
using Zenject;

namespace Dajjsand.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameplayObjectsContainer _gameplayObjectsContainer;

        public override void InstallBindings()
        {
            Container.Bind<GameplayObjectsContainer>().FromInstance(_gameplayObjectsContainer).AsSingle().NonLazy();
            Container.BindInterfacesTo<MobileInputService>().AsSingle().NonLazy();
            // Container.BindInterfacesTo<ComputerInputService>().AsSingle().NonLazy();
        }
    }
}