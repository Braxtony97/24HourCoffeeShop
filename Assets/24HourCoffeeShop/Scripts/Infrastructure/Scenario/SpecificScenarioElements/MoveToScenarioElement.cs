using UnityEngine;

public class MoveToScenarioElement : ScenarioElement
{
    [SerializeField] private GirlController _controller;
    [SerializeField] private Transform _point;
    
    public override void StartElement()
    {
        _controller.Complete += Complete;
        _controller.Complete += StopExtraAction;
        StartActions();
        _controller.MoveTo(_point);
    }

    private void StopExtraAction() =>
        StopActions();

    private void OnDestroy()
    {
        _controller.Complete -= Complete;
        _controller.Complete -= StopExtraAction;
    }
}
