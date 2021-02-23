using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TransformationsHud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameArea;
    [SerializeField] private Image objectImage;
    [SerializeField] private ArchitectPlaceItensController architectController;
    [SerializeField] private float rotateAngle = 30;
    [SerializeField] private float scaleValue = 3;

    [SerializeField] private HouseObject selectedHouseObject;


    void Start()
    {
        architectController.SelectedHouseObjectUpdated += UpdateValues;
        architectController.MouseButtonUnclicked += DeactivateRotation;
    }

    private void UpdateValues(HouseObject item)
    {
        selectedHouseObject = item;
        nameArea.text = item.houseItensSo.objectName;
        objectImage.sprite = item.houseItensSo.objectSprite;
    }

    private void DeactivateRotation()
    {
    }

    public void RotateItem(bool isLeft)
    {
        selectedHouseObject.RotateObject(isLeft ? rotateAngle : -rotateAngle);
    }
    
    public void ScaleItem(bool scalePositive)
    {
        selectedHouseObject.ScaleObject(scalePositive ? scaleValue : -scaleValue);
    }



}