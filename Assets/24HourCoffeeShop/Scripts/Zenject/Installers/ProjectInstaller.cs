using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private CoroutineRunner _coroutineRunner; 
    [SerializeField] private ScreenController _screenController; 

    public override void InstallBindings()
    {
        Container.Bind<ICoroutineRunner>().FromInstance(_coroutineRunner).AsSingle().NonLazy();
        Container.Bind<ScreenController>().FromInstance(_screenController).AsSingle().NonLazy();

        Container.Bind<SceneLoader>().AsSingle();

        Container.Bind<IState>().To<GameplayState>().AsSingle();
        Container.Bind<IState>().To<MainMenuState>().AsSingle();

        Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle(); 
    }
}
