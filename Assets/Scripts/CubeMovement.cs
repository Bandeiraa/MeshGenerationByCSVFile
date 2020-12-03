using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed; //Left or Right, A or D keys to move horizontally
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed; //Up or Down, W or S keys to move Vertically
        transform.Translate(horizontal, 0, vertical); //To move by input key (-1 to 1 * 1/Delta Time * Speed)
    }
}
