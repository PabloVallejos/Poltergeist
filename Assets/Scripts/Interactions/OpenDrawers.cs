using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDrawers : MonoBehaviour
{
    public Power pwr;
    public Points pnts;
    public GameObject gs;
    private int i;

    private bool isMouseOver;
    private bool cajonAbierto;
    
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        pwr = FindObjectOfType<Power>();
        pnts = FindObjectOfType<Points>();
        gs = GameObject.FindGameObjectWithTag("Player");
        cajonAbierto = false;
        animator.SetBool("Closed", true);
        animator.SetBool("Opened", false);
        i = 0;
        
    }
   
    private void OnMouseEnter()
    {
        isMouseOver = true;
        if ( pwr.pwr < 2)
        {
            gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
        }

        if (pwr.pwr >= 2)
        {
            gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
        }
    }

    private void OnMouseExit()
    {
            isMouseOver= false;
        
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        
    }

    private void OnMouseDown()
    {
        if (!cajonAbierto && pwr.pwr >= 2 )
        {
                AkSoundEngine.PostEvent("Play_drawer", gameObject);
                if(animator.enabled == false) { animator.enabled = true; }
                animator.SetBool("Opened", true);
                animator.SetBool("Closed", false);
                cajonAbierto = true;
                pwr.pwr -= 2;
            if (i == 0)
            {
                pnts.puntos += 25;
                i++;
            }
            if (i> 0)
            {
                pnts.puntos += 5;
            }
           
            
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        }
        if (cajonAbierto && pwr.pwr >= 2 )
        {
            AkSoundEngine.PostEvent("Play_drawer", gameObject);
            animator.SetBool("Closed", true);
            animator.SetBool("Opened", false);
            cajonAbierto = false;
            pwr.pwr -= 2;
            pnts.puntos += 5;
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        }
    }
    private void Update()
    {
        if (isMouseOver)
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
