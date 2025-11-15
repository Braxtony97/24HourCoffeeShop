using System;
using Zenject;

public class GameplayState : IState
{
    private SceneLoader _loader;
    private ScreenController _screenController;

    [Inject]
    public GameplayState(SceneLoader loader, ScreenController screenController)
    {
        _loader = loader;
        _screenController = screenController;
    }

    public void Enter()
    {
        _loader.LoadScene(GameEnums.Scenes.Gameplay, OnLoaded);
    }

    private void OnLoaded()
    {
        _screenController.CreateScreen(GameEnums.ScreenType.PlaymodeScreen);
    }

    public void Exit()
    {
    }
}

