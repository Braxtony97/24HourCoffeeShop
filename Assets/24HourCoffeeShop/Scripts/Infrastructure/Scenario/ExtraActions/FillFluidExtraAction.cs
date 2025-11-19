using Zenject;

public class FillFluidExtraAction : ExtraAction
{
    private IGameStateMachine _gameStateMachine;
    private SoundController _soundController;

    [Inject]
    public void Construct(IGameStateMachine gameStateMachine, SoundController soundController)
    {
        _gameStateMachine = gameStateMachine;
        _soundController = soundController;
    }

    public override void StartExtraAction()
    {
        _soundController.PlaySound(GameEnums.Sounds.CoffeeFill);
    }
}
