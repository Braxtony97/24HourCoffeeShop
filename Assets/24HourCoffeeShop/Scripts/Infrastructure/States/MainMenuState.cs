using System;
using UnityEngine.SceneManagement;
using Zenject;

public class MainMenuState : IState
{
    private SceneLoader _loader;
    private ScreenController _screenController;

    [Inject]
    public MainMenuState(SceneLoader loader, ScreenController screenController)
    {
        _loader = loader;
        _screenController = screenController;
    }

    public void Enter()
    {
        _loader.LoadScene(GameEnums.Scenes.MainMenu, OnLoaded);
    }

    private void OnLoaded()
    {
        _screenController.CreateScreen(GameEnums.ScreenType.MainMenuScreen);
    }

    public void Exit()
    {
    }
}
