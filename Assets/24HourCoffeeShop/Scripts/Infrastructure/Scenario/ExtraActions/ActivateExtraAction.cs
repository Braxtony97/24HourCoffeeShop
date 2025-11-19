using System;
using UnityEngine;

public class ActivateExtraAction : ExtraAction
{
    [SerializeField] private bool _isActivate;
    [SerializeField] private GameObject[] _gameObjects;

    public override void StartExtraAction() => 
        ActivateObjects();

    public override void StopExtraAction()
    {
    }

    private void ActivateObjects()
    {
        foreach (GameObject gameObject in _gameObjects)
        {
            gameObject.SetActive(_isActivate);
        }
    }
}
