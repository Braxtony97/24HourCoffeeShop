using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuScreen : BaseScreen
{
    [SerializeField] private Button _play;

    private IGameStateMachine _gameStateMachine;
    private SoundController _soundController;

    [Inject]
    public void Construct(IGameStateMachine gameStateMachine, SoundController soundController)
    {
        _gameStateMachine = gameStateMachine;
        _soundController = soundController;
    }

    public override void Initialize()
    {
        _play.onClick.AddListener(EnterGameplayState);
    }

    private void EnterGameplayState()
    { 
        _gameStateMachine.Enter<GameplayState>();
        _soundController.PlaySound(GameEnums.Sounds.Ambient, true);
    }

    public override void Deinitialize()
    {
        _play.onClick.RemoveListener(EnterGameplayState);
    }
}
