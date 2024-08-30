using Dajjsand.Controllers;
using Zenject;

namespace Dajjsand.Installers
{
    public class ControllersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelProgressionController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemiesController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BulletsController>().AsSingle().NonLazy();
        }
    }
}