using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlamShelf : MonoBehaviour
{
    public float pushForce = 50f;

    public bool canBeClicked = true;
    private bool isMouseOver = false;   
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
        if (canBeClicked && GameObject.FindGameObjectsWithTag("Orb").Length == 0)
        {
            gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
        }
        else
        {
            gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
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
        if (canBeClicked && GameObject.FindGameObjectsWithTag("Orb").Length == 0)
        {
                canBeClicked = false; // desactiva el clickeo para que la acción no se repita
                rb.AddForce(transform.forward * pushForce, ForceMode.Impulse);

        
            pnts.puntos += 205;
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
        if (GameObject.FindGameObjectsWithTag("Orb").Length > 0)
        {
            gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
        }
        else
        {
            gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
        }
    }
}

