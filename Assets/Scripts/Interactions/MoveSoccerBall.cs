using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSoccerBall : MonoBehaviour
{
    public float pushForce = 10f; 
 
    public bool canBeClicked = true;

    private bool isMouseOver = false;
    private Rigidbody rb;

    public Power pwr;
    public Points pnt;
    public GameObject gs;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pwr = FindObjectOfType<Power>();
        pnt = FindObjectOfType<Points>();
        gs = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
        if (canBeClicked && pwr.pwr < 2)
        {
            gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
        }

        if (canBeClicked && pwr.pwr >= 2)
        {
            gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
        }
    }
    private void OnMouseExit()
    {
        isMouseOver = false;
        if (canBeClicked)
        {
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        }
    }

    void OnMouseDown()
    {
        if (isMouseOver&&canBeClicked && pwr.pwr >= 2)
        {
                canBeClicked = false; // desactiva el clickeo para que la acción no se repita
                rb.AddForce(transform.forward * -pushForce, ForceMode.Impulse);
                rb.AddForce(transform.right * -pushForce, ForceMode.Impulse);
                pwr.pwr -= 2;
                pnt.puntos += 25;
                gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        }
    }
    private void Update()
    {
        if (isMouseOver&&canBeClicked)
        {
            UpdateCursorColor();
        }
    }

    private void UpdateCursorColor()
    {
        if (pwr.pwr < 2)
        {
            gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
        }
        else
        {
            gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
        }
    }
}
