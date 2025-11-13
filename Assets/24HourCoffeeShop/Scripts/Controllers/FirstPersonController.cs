using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpHeight = 1.5f;

    [Header("Mouse Settings")]
    [SerializeField] private float _mouseSensitivity = 2f;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _maxLookAngle = 85f;

    private CharacterController _controller;
    private GameInput _input;
    private Vector2 _moveInput;
    private Vector2 _lookInput;
    private Vector3 _velocity;
    private float _xRotation = 0f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _input = new GameInput();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        _input.Player.Enable();
        _input.Player.Move.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        _input.Player.Move.canceled += _ => _moveInput = Vector2.zero;

        _input.Player.Look.performed += ctx => _lookInput = ctx.ReadValue<Vector2>();
        _input.Player.Look.canceled += _ => _lookInput = Vector2.zero;

        _input.Player.Jump.performed += _ => TryJump();
    }

    private void OnDisable()
    {
        _input.Player.Disable();
    }

    private void Update()
    {
        HandleMovement();
        HandleLook();
    }

    private void HandleMovement()
    {
        Vector3 move = transform.right * _moveInput.x + transform.forward * _moveInput.y;
        _controller.Move(move * _moveSpeed * Time.deltaTime);

        if (_controller.isGrounded && _velocity.y < 0)
            _velocity.y = -2f;

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void HandleLook()
    {
        float mouseX = _lookInput.x * _mouseSensitivity * Time.deltaTime;
        float mouseY = _lookInput.y * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -_maxLookAngle, _maxLookAngle);

        transform.Rotate(Vector3.up * mouseX);
        _cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }

    private void TryJump()
    {
        if (_controller.isGrounded)
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
    }
}
