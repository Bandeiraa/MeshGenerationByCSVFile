using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObjectType
{
    Bed, Chair, Table
}

[CreateAssetMenu(fileName = "HouseObject", menuName = "HouseObject", order = 1)]
public class HouseItensSO : ScriptableObject
{
    [SerializeField] public Sprite objectSprite;
    [SerializeField] public string objectName;
    [SerializeField] public ObjectType objectType;
    [SerializeField] public GameObject objectPrefab;
}
