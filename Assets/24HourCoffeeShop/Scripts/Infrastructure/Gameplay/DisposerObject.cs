using UnityEngine;

public class DisposerObject : MonoBehaviour, IDisposer
{
    [SerializeField] private GameEnums.GrabItems _itemType;

    public bool CanDisposer(GameEnums.GrabItems item)
    {
        if (item == _itemType)
            return true;

        return false;
    }

    public void Disposer(IGrabbable grabbable)
    {
        if (CanDisposer(grabbable.ItemType))
        {
            if (grabbable is MonoBehaviour grabbableMono)
            {
                Destroy(grabbableMono.gameObject);
            }
        }
    }
}
