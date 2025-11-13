using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuScreen : BaseScreen
{
    [SerializeField] private Button _play;

    private IGameStateMachine _gameStateMachine;

    [Inject]
    public void Construct(IGameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public override void Initialize()
    {
        _play.onClick.AddListener(EnterGameplayState);
    }

    private void EnterGameplayState() =>
        _gameStateMachine.Enter<GameplayState>();

    public override void Deinitialize()
    {
        _play.onClick.RemoveListener(EnterGameplayState);
    }
}
