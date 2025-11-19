using System.Collections;
using UnityEngine;

public class WaitScenarioElement : ScenarioElement
{
    [SerializeField] private float _delay;

    public override void StartElement() => 
        StartCoroutine(Wait());

    private IEnumerator Wait()
    {
        float delay = 0;

        while (delay < _delay)
        {
            delay += Time.deltaTime;
            yield return null;
        }

        Complete();
    }
}
