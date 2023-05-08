using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    Vector3 temp;
    public float x =40;
    public float y =-35;


    void Update()
    {
        //Fantasma sigue el mouse
        //temp = Input.mousePosition;
        temp.x = Input.mousePosition.x + x;
        temp.y = Input.mousePosition.y + y;
        this.transform.position = temp;
    }
}
