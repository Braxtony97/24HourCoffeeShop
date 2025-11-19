using System;
using UnityEngine;

public abstract class ScenarioElement : MonoBehaviour
{
    public Action<ScenarioElement> OnCompleted;
    public ExtraAction[] ExtraActions;

    public abstract void StartElement();

    public virtual void Complete() => 
        OnCompleted?.Invoke(this);

    protected void StartActions()
    {
        foreach (ExtraAction action in ExtraActions)
            action.StartExtraAction();
    }

    protected void StopActions()
    {
        foreach (ExtraAction action in ExtraActions)
            action.StopExtraAction();
    }
}