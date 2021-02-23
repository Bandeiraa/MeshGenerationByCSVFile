using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class ArchitectPlaceItensController : MonoBehaviour
{
    [SerializeField] private Transform selectedObject;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float worldY = 0;
    [SerializeField] private LayerMask mLayerMask;
    [SerializeField] private LayerMask placebleAreaMask;
    
    public event Action<HouseObject> SelectedHouseObjectUpdated = delegate { };
    public event Action MouseButtonUnclicked = delegate { };

    [SerializeField] private HouseObject lastItemSelected;
    private ArchitectController _playerController;


    private void Awake()
    {
        _playerController = new ArchitectController();
    }

    private void Start()
    {
        _playerController.Mouse.MouseSelect.performed += _ => SpawnItem();

        
    }

    private void SpawnItem()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // _ableToSelect = false;
            Vector3 mousePosition = _playerController.Mouse.MousePosition.ReadValue<Vector2>();
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            mousePosition.y = worldY;
            Vector3 placeblePosition = mousePosition;
            placeblePosition.y = 0.007f;

            if (IsPlacebleArea(placeblePosition))
            {
                var hittedObject = IsHittingObject(mousePosition);
                if (!hittedObject || lastItemSelected != hittedObject.GetComponent<HouseObject>())
                {
                    Transform newObject;
                    newObject = !hittedObject ? 
                        Instantiate(selectedObject, placeblePosition, Quaternion.identity, transform)
                        : hittedObject.transform;

                    if (lastItemSelected)
                    {
                        lastItemSelected.ChangeItemState(false);
                    }

                    lastItemSelected = newObject.GetComponentInParent<HouseObject>();
                    lastItemSelected.ChangeItemState(true);
                    
                    SelectedHouseObjectUpdated(lastItemSelected);

                }
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

    private bool IsPlacebleArea(Vector3 position)
    {
        Collider[] result = new Collider[1];
        int size = Physics.OverlapBoxNonAlloc(position, selectedObject.localScale / 2, result, Quaternion.identity,
            placebleAreaMask);


        return size == 1;
    }

    private Collider IsHittingObject(Vector3 position)
    {
        Collider[] hitColliders = Physics.OverlapBox(position, selectedObject.localScale / 2,
            Quaternion.identity, mLayerMask);


        return hitColliders.Length != 0 ? hitColliders[0] : null;
    }


    private void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}