using System;
using UnityEngine;

public abstract class ScenarioElement : MonoBehaviour
{
    public Action<ScenarioElement> OnCompleted;
    public ExtraAction ExtraAction;

    public abstract void StartElement();
    public virtual void Complete() => 
        OnCompleted?.Invoke(this);
}