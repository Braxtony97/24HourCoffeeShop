using UnityEngine;
using Zenject;

public class GameBootstrapper : MonoBehaviour
{
    private IGameStateMachine _gameStateMachine;

    [Inject]
    public void Construct(IGameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
        _gameStateMachine.Enter<MainMenuState>();
    }
}
