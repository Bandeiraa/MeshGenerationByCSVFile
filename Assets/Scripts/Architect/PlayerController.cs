using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera = null;
    [SerializeField] private float mouseSensibility;
    [SerializeField] private bool lockCursor;
    [SerializeField] private float walkSpeed = 6f;
    [SerializeField] private float gravity = -13.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField][Range(0f,0.5f)] private float moveSmoothTime = 0.3f;
    [SerializeField][Range(0f,0.5f)] private float mouseSmoothTime= 0.03f;

    private float _cameraPicht = 0;
    private float _velocityY = 0;
    private CharacterController _characterController = null;
    private PlayerInputs _playerInputs;

    private Vector2 _currentDir = Vector2.zero;
    private Vector2 _currentDirVelocity = Vector2.zero;
    
    private Vector2 _currentMouseDelta = Vector2.zero;
    private Vector2 _currentMouseDeltaVelocity = Vector2.zero;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerInputs = new PlayerInputs();
    }
    
    void Start()
    {
        // _playerInputs.Terrain.Jump.performed += _ => Jump();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    

    private void OnEnable()
    {
        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }


    private void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = _playerInputs.Terrain.MouseDelta.ReadValue<Vector2>();
        _currentMouseDelta = Vector2.SmoothDamp(_currentMouseDelta, targetMouseDelta,
            ref _currentMouseDeltaVelocity, mouseSmoothTime);

        _cameraPicht -= _currentMouseDelta.y * mouseSensibility;

        _cameraPicht = Mathf.Clamp(_cameraPicht, -90f, 90f);
        playerCamera.transform.localEulerAngles = Vector3.right * _cameraPicht;
        transform.Rotate(Vector3.up * (_currentMouseDelta.x * mouseSensibility));
    }

    void UpdateMovement()
    {
        Vector2 targetDir = _playerInputs.Terrain.Movement.ReadValue<Vector2>();

        _currentDir = Vector2.SmoothDamp(_currentDir, targetDir, ref _currentDirVelocity, moveSmoothTime);

        if (_characterController.isGrounded)
            _velocityY = 0.0f;
        
        _velocityY += _playerInputs.Terrain.Jump.triggered && _characterController.isGrounded ? jumpForce : gravity * Time
        .deltaTime ;
        
        Vector3 velocity = (transform.forward * _currentDir.y + transform.right * _currentDir.x)
        + Vector3.up * _velocityY;
        _characterController.Move(velocity * (Time.deltaTime * walkSpeed));
    }
}
