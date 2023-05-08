using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlamBook : MonoBehaviour
{
    public float pushForce = 10f; // fuerza con la que se empujará el libro hacia adelante
    public float pushBackForce = 2f; // fuerza con la que se empujará el libro hacia atrás antes de salir disparado
    public bool canBeClicked = true; // indica si el libro puede ser clickeado o no
    private bool isMouseOver=false;
    public Power pwr;
    public Points pnts;
    public GameObject gs;
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pwr = FindObjectOfType<Power>();
        pnts = FindObjectOfType<Points>();
        gs = GameObject.FindGameObjectWithTag("Player");
      
    }

    private void OnMouseEnter()
    {
        isMouseOver= true;
        if (canBeClicked && pwr.pwr < 4)
        {
            gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
            
        }

        if (canBeClicked && pwr.pwr >= 4)
        {
            gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
        }
    }

    private void OnMouseExit()
    {
        isMouseOver= false;
        if (canBeClicked)
        {
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        }
    }

    void OnMouseDown()
    {
        if (canBeClicked && pwr.pwr >= 4)
        {
                AkSoundEngine.PostEvent("Play_book", gameObject);
            
                canBeClicked = false; // desactiva el clickeo para que la acción no se repita
                rb.AddForce(transform.forward * pushBackForce, ForceMode.Impulse); // empuja el libro hacia atrás
                rb.AddForce(transform.forward * -pushForce, ForceMode.Impulse); // empuja el libro hacia adelante
                pwr.pwr -= 4;
                pnts.puntos += 45;
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        }
    }
    private void Update()
    {
        if (isMouseOver && canBeClicked)
        {
            UpdateCursorColor();
        }

    }

    private void UpdateCursorColor()
    {
        if (pwr.pwr < 4)
        {
            gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
        }
        else
        {
            gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
        }
    }
}


