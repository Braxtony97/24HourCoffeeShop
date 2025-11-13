using Zenject;

public class GameplayState : IState
{
    private SceneLoader _loader;

    [Inject]
    public GameplayState(SceneLoader loader)
    {
        _loader = loader;
    }

    public void Enter()
    {
        UnityEngine.Debug.Log("Entered GameplayState");
    }

    public void Exit()
    {
    }
}

