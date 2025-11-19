using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GrabController : MonoBehaviour
{
    [SerializeField] private RaycastInteractor _interactor;
    [SerializeField] private Transform _holdPoint;

    private IGrabbable _holdObject = null;

    [Inject] private GameInput _input;

    public void Start()
    {
        _input.Player.Grab.performed += HandleGrabPressed;
        _input.Player.Insert.performed += HandleInsertPressed;
    }

    private void HandleInsertPressed(InputAction.CallbackContext context)
    {
        if (_holdObject != null)
        {
            TryInsert();
        }
    }

    private void HandleGrabPressed(InputAction.CallbackContext context)
    {
        if (_holdObject == null)
            TryGrab();
        else
            Drop();
    }

    private void TryGrab()
    {
        if (_interactor.TryGetObject(out IGrabbable grabbableObject))
        {
            _holdObject = grabbableObject;
            grabbableObject.Grab(_holdPoint);
        }
    }

    private void Drop()
    {
        if (_interactor.TryGiveObject(out IDisposer dissposerObject, _holdObject.LayerMask))
        {
            dissposerObject.Disposer(_holdObject);
            _holdObject = null;
            return;
        }

        _holdObject.Drop();
        _holdObject = null;
    }

    private void TryInsert()
    {
        if (_interactor.TryInsertObject(out IInsertable insertable, _holdObject.LayerMask))
        {
            insertable.Insert(_holdObject);
            _holdObject = null;
        }
    }

    private void OnDisable()
    {
        _input.Player.Grab.performed -= HandleGrabPressed;
        _input.Player.Insert.performed -= HandleInsertPressed;
    }
}
