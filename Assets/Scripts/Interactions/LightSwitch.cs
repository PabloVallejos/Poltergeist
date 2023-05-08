using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSwitch : MonoBehaviour
{
    public Light luzDeLaHabitacion;

    public Power pwr;
    public Points pnts;
    public GameObject gs;
    private int lightBreak;

    private bool isMouseOver = false;
    private bool luzEncendida = false;

    private void Start()
    {
        pwr = FindObjectOfType<Power>();
        pnts = FindObjectOfType<Points>();
        gs = GameObject.FindGameObjectWithTag("Player");
        lightBreak = 0;
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
        if (lightBreak < 4)
        {

            if (pwr.pwr < 1)
            {
                gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
            }

            if (pwr.pwr >= 1)
            {
                gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
            }
        }
        else { gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175); }
    }

    private void OnMouseExit()
    {
        
            isMouseOver= false;
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        
    }

    private void OnMouseDown()
    {
        if (lightBreak < 4)
        {
            if (pwr.pwr >= 1)
            {
                AkSoundEngine.PostEvent("Play_light_click", gameObject);
                lightBreak++;
                luzEncendida = !luzEncendida;
                luzDeLaHabitacion.enabled = luzEncendida;
                pwr.pwr -= 1;
                pnts.puntos += 15;
                gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
            }
        }
        else { luzDeLaHabitacion.enabled = false;}
    }
    private void Update()
    {
        if (isMouseOver && lightBreak<4)
        {
            UpdateCursorColor();
        }

    }

    private void UpdateCursorColor()
    {
        if (pwr.pwr < 1)
        {
            gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
        }
        else
        {
            gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
        }
    }
}
