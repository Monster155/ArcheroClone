using Dajjsand.Factories;
using Zenject;

namespace Dajjsand.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputControllerFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GunFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BulletFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemyFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle().NonLazy();
        }
    }
}