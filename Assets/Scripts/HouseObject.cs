using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseObject : MonoBehaviour
{

    private Outline _objectOutline;
    // Start is called before the first frame update
    void Awake()
    {
        _objectOutline = GetComponent<Outline>();
    }

    public void ChangeItemState(bool activate)
    {
        _objectOutline.enabled = activate;
    }
}
