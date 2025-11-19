using System.Collections;
using UnityEngine;

public class SetObjectZoneScenarioElement : ScenarioElement
{
    [SerializeField] private InsertableObject _zone;
    [SerializeField] private int _fillTime = 3;

    private Coroutine _fillCoroutine;

    public override void StartElement()
    {
        _zone.OnInsert += WaitForFill;
    }

    private void WaitForFill()
    {
        _fillCoroutine = StartCoroutine(FillRoutine());
        ExtraAction.StartExtraAction();
    }

    private IEnumerator FillRoutine()
    {
        float timer = _fillTime;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        Complete();
    }

    private void OnDestroy()
    {
        _zone.OnInsert -= WaitForFill;
        StopCoroutine(_fillCoroutine);
    }
}
