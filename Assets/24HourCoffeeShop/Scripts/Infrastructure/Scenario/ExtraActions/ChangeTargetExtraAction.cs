using UnityEngine;
using Zenject;

public class ChangeTargetExtraAction : ExtraAction
{
    [SerializeField] private GameObject _gameObejct;
    [SerializeField] private Transform _target;

    public override void StartExtraAction()
    {
        _gameObejct.transform.position = _target.position;
        _gameObejct.transform.rotation = _target.rotation;
    }

    public override void StopExtraAction()
    {
    }
}
