using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrabbableObject : MonoBehaviour, IGrabbable
{
    public GameEnums.GrabItems ItemType => _item;
    public LayerMask LayerMask { get => _layerMask; }

    [SerializeField] private GameEnums.GrabItems _item;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private LayerMask _holdLayerMask;

    private LayerMask _layerMask;
    private int _originalLayer;

    private void Start() => 
        _originalLayer = gameObject.layer;

    public void Grab(Transform parent)
    {
        _rigidbody.isKinematic = true;
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        _layerMask = _holdLayerMask;
        gameObject.layer = GetFirstLayerFromMask(_holdLayerMask);
    }

    public void Drop()
    {
        transform.SetParent(null);
        _rigidbody.isKinematic = false;

        _layerMask = default;
        gameObject.layer = _originalLayer;
    }

    private int GetFirstLayerFromMask(LayerMask mask) 
    {
        int layerNumber = 0;
        int layer = mask.value;
        while (layer > 0)
        {
            layer = layer >> 1;
            layerNumber++;
        }
        return layerNumber - 1;
    }
}
