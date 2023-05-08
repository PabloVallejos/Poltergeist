using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GhostShadow : MonoBehaviour
{
    public Power pwr;
    public Points pnts;
    public GameObject gs;

    private bool isMouseOver = false;
    private bool clickOnWindow = false;
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
        if (!clickOnWindow && pwr.pwr < 5)
        {
            gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
        }

        if (!clickOnWindow && pwr.pwr >= 5)
        {
            gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
        }
    }

    private void OnMouseExit()
    {
        isMouseOver= false;
        if (!clickOnWindow)
        {
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        }
    }

    private void OnMouseDown()
    {
        if (isMouseOver&&!clickOnWindow && pwr.pwr >= 5)
        {
            AkSoundEngine.PostEvent("Play_window_f", gameObject);
            animator.enabled = true;
            clickOnWindow = true;
            pwr.pwr -= 5;
            pnts.puntos += 55;
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        }
    }
    private void Update()
    {
        if (isMouseOver && !clickOnWindow)
        {
            UpdateCursorColor();
        }

    }

    private void UpdateCursorColor()
    {
        if (pwr.pwr < 5)
        {
            gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
        }
        else
        {
            gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
        }
    }
}
