using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.InputSystem;


enum CollisionType{
    HitObject,HitFloor, HitWall
}

public class ArchitectPlaceItensController : MonoBehaviour
{
    [SerializeField] private Transform selectedObject;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float worldY = 0;
    [SerializeField] private LayerMask hitingMask;
    [SerializeField] private LayerMask placebleAreaMask;
    private const float DistanceToFloor = 0.007f;
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
        _playerController.Mouse.MouseSelect.started += _ => SpawnItem();
        _playerController.Mouse.MouseSelect.performed += _ => DragObject();
        _playerController.Mouse.MouseSelect.canceled += _ => DropObject();
    }

    private void DragObject()
    {   
        print("carregou");

        StartCoroutine(nameof(HoldingItem));
    }

    private void DropObject()
    {
        print("dropou");
        // print("ended "+ _playerController.Mouse.MousePosition.ReadValue<Vector2>());
        StopCoroutine(nameof(HoldingItem));
    }

    private void SpawnItem()
    {
        // print("started " + _playerController.Mouse.MousePosition.ReadValue<Vector2>());

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // _ableToSelect = false;
            var mousePosition = GetMousePosition();
            Vector3 placeblePosition = mousePosition;
            placeblePosition.y = DistanceToFloor;

            if (!IsPlacebleArea(placeblePosition)) return;
            
            Collider hittedObject;
            var collisionType = IsHittingObject(mousePosition,out hittedObject);

            HouseObject newObject;
            switch (collisionType)
            {
                case CollisionType.HitObject:
                    if (lastItemSelected != hittedObject.GetComponent<HouseObject>())
                    {
                        newObject = hittedObject.GetComponentInParent<HouseObject>();
                        UpdateLastItemSelected(newObject);
                    }
                    break;
                case CollisionType.HitFloor:
                    newObject = Instantiate(selectedObject, placeblePosition, Quaternion.identity,
                        transform).GetComponentInParent<HouseObject>();
                    UpdateLastItemSelected(newObject);


                    break;

            }
                
       
        }
    }

    private void UpdateLastItemSelected(HouseObject newObject)
    {
        if (lastItemSelected)
            lastItemSelected.ChangeItemState(false);
        
        lastItemSelected = newObject;
        lastItemSelected.ChangeItemState(true);
        SelectedHouseObjectUpdated(lastItemSelected);
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = _playerController.Mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        mousePosition.y = worldY;

        return mousePosition;
    }

    IEnumerator HoldingItem()
    {
        while (true)
        {
            yield return null;
            var mousePosition = GetMousePosition();
            mousePosition.y = DistanceToFloor;
            lastItemSelected.gameObject.transform.position = mousePosition;
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
        // var out a
        Collider[] result = new Collider[1];
        int size = Physics.OverlapBoxNonAlloc(position, selectedObject.localScale / 2, result, Quaternion.identity,
            placebleAreaMask);


        return size == 1;
    }

    private CollisionType IsHittingObject(Vector3 mousePosition, out Collider result)
    {
        Collider[] hitColliders = Physics.OverlapBox(mousePosition, selectedObject.localScale / 2,
            Quaternion.identity);
        
        if (hitColliders.Length == 1)
        {
            result = hitColliders[0];
            bool isAWall = hitColliders[0].gameObject.layer == LayerMask.NameToLayer("WallsLayer");
            return isAWall ? CollisionType.HitWall : CollisionType.HitObject;
        }
        
            
        result = hitColliders.Length != 0 ? hitColliders[0] : null;
      

        return hitColliders.Length != 0 ? CollisionType.HitObject : CollisionType.HitFloor;
    }


    private void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}