using Dajjsand.Controllers;
using Zenject;

namespace Dajjsand.Installers
{
    public class ControllersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LevelProgressionController>().AsSingle().NonLazy();
            Container.BindInterfacesTo<EnemiesController>().AsSingle().NonLazy();
            Container.BindInterfacesTo<PlayerController>().AsSingle().NonLazy();
            Container.BindInterfacesTo<BulletsController>().AsSingle().NonLazy();
        }
    }
}