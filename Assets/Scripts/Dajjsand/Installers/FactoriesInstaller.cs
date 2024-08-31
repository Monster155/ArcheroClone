using Dajjsand.Factories;
using Zenject;

namespace Dajjsand.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<InputControllerFactory>().AsSingle().NonLazy();
            Container.BindInterfacesTo<GunFactory>().AsSingle().NonLazy();
            Container.BindInterfacesTo<BulletFactory>().AsSingle().NonLazy();
            Container.BindInterfacesTo<EnemyFactory>().AsSingle().NonLazy();
            Container.BindInterfacesTo<PlayerFactory>().AsSingle().NonLazy();
        }
    }
}