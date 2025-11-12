using Zenject;
using Zenject.Asteroids;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IState>().To<GameplayState>().AsSingle();

        Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
    }
}
