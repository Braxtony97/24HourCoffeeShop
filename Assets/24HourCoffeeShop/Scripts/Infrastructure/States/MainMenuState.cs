using System;
using UnityEngine.SceneManagement;
using Zenject;

public class MainMenuState : IState
{
    private SceneLoader _loader;

    [Inject]
    public MainMenuState(SceneLoader loader)
    {
        _loader = loader;
    }

    public void Enter()
    {
        UnityEngine.Debug.Log("Entered MainMenuState");
        _loader.LoadScene("MainMenu", OnLoaded);
    }

    private void OnLoaded()
    {
        UnityEngine.Debug.Log("MainMenu Loaded");
    }

    public void Exit()
    {
    }
}
