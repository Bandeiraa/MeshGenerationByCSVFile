using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HouseObject : MonoBehaviour
{
    public HouseItensSO houseItensSo;
    private Outline _objectOutline;

    // Start is called before the first frame update
    void Awake()
    {
        _objectOutline = GetComponentInChildren<Outline>();
    }

    public void ChangeItemState(bool activate)
    {
        _objectOutline.enabled = activate;
    }

    public void RotateObject(float rotateAngle)
    {
        transform.Rotate(Vector3.up * rotateAngle);
    }

    public void ScaleObject(float scaleValue)
    {
        transform.localScale += Vector3.one * scaleValue;
    }
    
}