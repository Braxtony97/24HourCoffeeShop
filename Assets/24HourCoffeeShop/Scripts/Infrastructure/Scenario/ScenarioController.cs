using System.Collections.Generic;
using UnityEngine;

public class ScenarioController : MonoBehaviour
{
    [SerializeField] private List<ScenarioElement> _elementsList;

    private Queue<ScenarioElement> _elementsQueue;
    private ScenarioElement _currentElement;

    public void Start()
    {
        InitializeQueue();
        StartScenario();
    }

    private void InitializeQueue() => 
        _elementsQueue = new Queue<ScenarioElement>(_elementsList);

    private void StartScenario() => 
        RunNextElement();

    private void RunNextElement()
    {
        if (_elementsQueue.Count == 0)
            return;

        ScenarioElement element = _elementsQueue.Dequeue();
        _currentElement = element;

        element.OnCompleted += OnElementCompleted;
        element.StartElement();
    }

    private void OnElementCompleted(ScenarioElement element)
    {
        element.OnCompleted -= OnElementCompleted;
        RunNextElement();
    }
}
