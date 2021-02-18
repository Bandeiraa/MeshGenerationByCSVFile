using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ArchitectPlaceItensController : MonoBehaviour
{
    [SerializeField] private Transform selectedObject;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float worldY = 0;
    [SerializeField] private LayerMask mLayerMask;
    [SerializeField] private LayerMask placebleAreaMask;

    private bool _ableToSelect = false;
    private ArchitectController _playerController;


    private void Awake()
    {
        _playerController = new ArchitectController();
    }

    private void Start()
    {
        // _playerController.Mouse.MouseSelect.performed += _ => SpawnItem();
    }

    private void SpawnItem()
    {
        if (_ableToSelect)
        {
            _ableToSelect = false;
            Vector3 mousePosition = _playerController.Mouse.MousePosition.ReadValue<Vector2>();
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            mousePosition.y = worldY;
            Vector3 placeblePosition = mousePosition;
            placeblePosition.y -= selectedObject.localScale.y / 2;
            if (VerifyCollisions(placeblePosition, placebleAreaMask) && VerifyCollisions(mousePosition, mLayerMask))
            {
                Instantiate(selectedObject, mousePosition, Quaternion.identity);
            }
            
        }
    }

    private void OnEnable()
    {
        _playerController.Enable();
    }

    private void OnDisable()
    {
        _playerController.Disable();
    }

    private bool VerifyCollisions(Vector3 position, LayerMask mask)
    {
        Collider[] result = new Collider[1];
        int size = Physics.OverlapBoxNonAlloc(position, selectedObject.localScale / 2, result, Quaternion.identity,
            mask);

        if (mask == placebleAreaMask)
        {
            return size == 1;
        }
        else
        {
            return size == 0;
        }
    }

    public void SetAbleToClick(bool value)
    {

        _ableToSelect = value;
        SpawnItem();
    }

    private void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}