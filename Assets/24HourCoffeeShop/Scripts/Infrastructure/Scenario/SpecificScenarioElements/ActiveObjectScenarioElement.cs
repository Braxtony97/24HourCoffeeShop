using System.Collections;
using UnityEngine;

public class ActiveObjectScenarioElement : ScenarioElement
{
    [SerializeField] private float _delay;
    [SerializeField] private bool _isActivate;
    [SerializeField] private GameObject[] _gameObjects;



    public override void StartElement() => 
        StartCoroutine(ActivateObject());

    private IEnumerator ActivateObject()
    {
        float delay = 0;

        while (delay < _delay)
        {
            delay += Time.deltaTime;
            yield return null;
        }

        ActivateDeactivateObjects();
        Complete();
    }

    private void ActivateDeactivateObjects()
    {
        foreach (GameObject obj in _gameObjects)
        {
            obj.SetActive(_isActivate);
        }

        if (ExtraActions != null)
            StartActions();
    }
}
