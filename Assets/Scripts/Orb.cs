using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orb : MonoBehaviour
{
    public GameObject slamShelf; // Referencia al objeto estantería
    public GameObject gs;
    public bool canBeClicked = true;
    public Points pnts;

    private void Start()
    {
        gs = GameObject.FindGameObjectWithTag("Player");
        pnts = FindObjectOfType<Points>();
    }
    private void OnMouseEnter()
    {

        if (canBeClicked)
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
        if (canBeClicked)
        {
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        }
    }
    private void OnMouseDown()
    {
        // Al hacer click en el orbe, se destruye el objeto
        Destroy(gameObject);
        pnts.puntos += 10   ;
        // Se verifica si ya se han destruido los tres orbes
        if (GameObject.FindGameObjectsWithTag("Orb").Length == 0)
        {
            // Si se han destruido los tres orbes, se habilita el clickeo en la estantería
            slamShelf.GetComponent<SlamShelf>().canBeClicked = true;
        }
    }

}
