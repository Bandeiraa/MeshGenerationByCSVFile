using System;
using UnityEngine;
using UnityEngine.Serialization;


// [ExecuteInEditMode]
public class ListCreator : MonoBehaviour {


    [SerializeField]
    private GameObject item = null;

    [SerializeField] private float initialOffset= 30;
    [SerializeField] private float verticalOffset = 60;
    [SerializeField]
    private RectTransform content = null;

    public HouseItensSO[] houseItensSo = null;
    // Use this for initialization
    void Start () {
    
        //setContent Holder Height;
        content.sizeDelta = new Vector2(0, houseItensSo.Length * verticalOffset);
        
        

        for (int i = 0; i < houseItensSo.Length; i++)
        {
            
            // 60 width of item
            float spawnY = i * verticalOffset + initialOffset;
            //newSpawn Position
            Vector3 pos = new Vector3(0, -spawnY);
            //instantiate item
            GameObject spawnedItem = Instantiate(item,  transform);
            //setParent
            spawnedItem.transform.localPosition = pos;
            //get ItemDetails Component
            ItemDetails itemDetails = spawnedItem.GetComponent<ItemDetails>();
            //set name
            itemDetails.text.text = houseItensSo[i].objectName;
            //set image
            itemDetails.image.sprite = houseItensSo[i].objectSprite;  


        }
    }

  
}