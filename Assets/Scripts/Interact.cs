using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Image img; //Fantasma
    public Points points; //El sistema de puntos
    public Sprite[] spr; //Imagenes del objeto
    public int i; //Cuantos puntos da
    public int ID; //Orden de secuencia
    public int cost; //Coste de poder
    public Power pwr; //Medidor de energ�a
    float timer = 0;

    private void Start()
    {
        points = FindObjectOfType<Points>();
        pwr = FindObjectOfType<Power>();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {

            //Activa interacci�n con el objeto
            GetComponent<BoxCollider2D>().enabled = true;

            //Cambia la imagen del objeto
            GetComponent<SpriteRenderer>().sprite = spr[0];
        }
    }

    // Color del fantasma
    private void OnMouseEnter()
    {
        img.color = new Color32(255, 0, 0, 100);
    }
    private void OnMouseExit()
    {
        img.color = new Color32(255, 255, 255, 100);
    }

    //Sumar puntos
    private void OnMouseDown()
    {
        //Chequea si hay suficiente energ�a
        if(pwr.pwr >= cost)
        {
            //Resta energ�a
            pwr.pwr = pwr.pwr - cost;

            points.PointUp(i);
            points.curr = ID;
            //Desactiva interacci�n con el objeto
            GetComponent<BoxCollider2D>().enabled = false;

            //Cambia la imagen del objeto
            GetComponent<SpriteRenderer>().sprite = spr[1];

            timer = 10; //Tiempo para que se pueda volver a usar
        }
    }
}
