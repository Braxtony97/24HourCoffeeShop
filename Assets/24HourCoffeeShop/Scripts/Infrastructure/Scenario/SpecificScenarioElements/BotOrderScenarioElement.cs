using UnityEngine;

public class BotOrderScenarioElement : ScenarioElement
{
    [SerializeField] private BotController _bot;
    [SerializeField] private Transform _point;
    
    public override void StartElement()
    {
        _bot.Complete += Complete;
        _bot.MoveTo(_point);
    }

    private void OnDestroy() => 
        _bot.Complete -= Complete;
}
