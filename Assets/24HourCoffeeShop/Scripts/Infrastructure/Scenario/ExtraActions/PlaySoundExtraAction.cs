using UnityEngine;
using Zenject;

public class PlaySoundExtraAction : ExtraAction
{
    [SerializeField] private GameEnums.Sounds _sound;

    private IGameStateMachine _gameStateMachine;
    private SoundController _soundController;

    [Inject]
    public void Construct(IGameStateMachine gameStateMachine, SoundController soundController)
    {
        _gameStateMachine = gameStateMachine;
        _soundController = soundController;
    }

    public override void StartExtraAction() => 
        _soundController.PlaySound(_sound);

    public override void StopExtraAction() => 
        _soundController.StopAllSounds();
}
