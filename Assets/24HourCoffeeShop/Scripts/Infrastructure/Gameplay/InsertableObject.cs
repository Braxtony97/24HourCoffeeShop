using UnityEngine;

public class InsertableObject : MonoBehaviour, IInsertable
{
    [SerializeField] private GameEnums.GrabItems _itemType;
    [SerializeField] private Transform _insertPoint;

    public bool CanInsert(GameEnums.GrabItems itemType)
    {
        if (itemType == _itemType)
            return true;

        return false;
    }

    public void Insert(IGrabbable grabbable)
    {
        if (CanInsert(grabbable.ItemType))
        {
            grabbable.Drop();
            Transform transform = (grabbable as MonoBehaviour).transform;

            transform.position = _insertPoint.position;
            transform.rotation = _insertPoint.rotation;

            transform.SetParent(_insertPoint);
        }
    }
}