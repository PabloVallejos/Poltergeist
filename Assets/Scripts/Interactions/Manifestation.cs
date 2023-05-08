using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manifestation : MonoBehaviour
{
    public Power pwr;
    public Points pnts;
    public GameObject gs;
    public GameObject M;

    private bool isMouseOver = false;
    private bool manifested = false;
    private Animator animator;

    

    private void Start()
    {
        animator = GetComponent<Animator>();
        pwr = FindObjectOfType<Power>();
        pnts = FindObjectOfType<Points>();
        gs = GameObject.FindGameObjectWithTag("Player");
        M.GetComponent<Animator>().enabled = false;
      
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
        if (!manifested && pwr.pwr < 6)
        {
            gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
        }

        if (!manifested && pwr.pwr >= 6)
        {
            gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
        }
    }

    private void OnMouseExit()
    {
        isMouseOver=false;
        if (!manifested)
        {
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        }
    }

    private void OnMouseDown()
    {
        if (!manifested && pwr.pwr >= 6)
        {
            AkSoundEngine.PostEvent("Play_under_bed", gameObject);
            manifested = true;
            pwr.pwr -= 6;
            pnts.puntos += 65;
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
            M.GetComponent<Animator>().enabled = true;
        }
    }
    private void Update()
    {
        if (isMouseOver && !manifested)
        {
            UpdateCursorColor();
        }

    }

    private void UpdateCursorColor()
    {
        if (pwr.pwr < 6)
        {
            gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
        }
        else
        {
            gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
        }
    }
}

