using UnityEngine;

public class RaycastInteractor : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _insertLayerMask;

    public bool TryGetObject(out IGrabbable grabbable)
    {
        grabbable = null;

        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, _distance))
        {
            grabbable = hit.collider.GetComponentInParent<IGrabbable>();
        }

        return grabbable != null;
    }

    public bool TryInsertObject(out IInsertable insertable, LayerMask mask = default)
    {
        insertable = null;

        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, _distance, ~mask))
        {
            insertable = hit.collider.GetComponentInParent<IInsertable>();
        }

        return insertable != null;
    }
}
