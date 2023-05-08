using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public Power pwr;
    public Points pnts;
    public GameObject gs;

    private bool isMouseOver = false;
    private bool doorOpen = false;
    private Animator animator;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        pwr = FindObjectOfType<Power>();
        pnts = FindObjectOfType<Points>();
        gs = GameObject.FindGameObjectWithTag("Player");
       
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
        if (!doorOpen && pwr.pwr < 2)
        {
            gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
        }

        if (!doorOpen && pwr.pwr >= 2)
        {
            gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
        }
    }
    private void OnMouseExit()
    {
        isMouseOver= false;
        if (!doorOpen)
        {
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        }
    }

    private void OnMouseDown()
    {
        if (!doorOpen && pwr.pwr >= 2)
        {
                AkSoundEngine.PostEvent("Play_door", gameObject);
                animator.enabled = true;
                doorOpen = true;
                pwr.pwr -= 2;
                pnts.puntos += 25;
                gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        }
    }
    private void Update()
    {
        if (isMouseOver && !doorOpen)
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
