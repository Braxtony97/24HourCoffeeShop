using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private GameBootstrapper _gameBootstrapper;

    public override void InstallBindings()
    {
        Container.Bind<GameBootstrapper>().FromInstance(_gameBootstrapper).AsSingle().NonLazy();
    }
}
