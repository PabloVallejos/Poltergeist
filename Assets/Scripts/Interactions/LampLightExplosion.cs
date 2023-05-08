using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LampLightExplosion : MonoBehaviour
{
    public Power pwr;
    public Points pnts;
    public GameObject gs;

    private Light lampLight;
    private bool isExploding = false;
    private bool isMouseOver = false;
    private float currentIntensity = 4f;
    private float maxIntensity = 10f;
    private float explosionIntensity = 25f;

    private void Start()
    {
        lampLight = GetComponent<Light>();
        pwr = FindObjectOfType<Power>();
        pnts = FindObjectOfType<Points>();
        gs = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
        if (!isExploding && pwr.pwr < 1)
        {
            gs.GetComponent<Image>().color = new Color32(255, 0, 0, 175);
        }

        if (!isExploding && pwr.pwr >= 1)
        {
            gs.GetComponent<Image>().color = new Color32(0, 255, 0, 175);
        }
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
        if (!isExploding)
        {
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
        }
    }

    private void OnMouseDown()
    {
        if (!isExploding && pwr.pwr >= 1)
        {
            currentIntensity += 1f;
            lampLight.intensity = currentIntensity;
            pnts.puntos += 15;
            pwr.pwr -= 1;
            gs.GetComponent<Image>().color = new Color32(255, 255, 255, 175);
            AkSoundEngine.PostEvent("Play_light_table", gameObject);
            if (currentIntensity >= maxIntensity)
            {
                isExploding = true;
                lampLight.intensity = explosionIntensity;
                Destroy(lampLight, 0.3f);
            }
        }
    }
    private void Update()
    {
        if (isMouseOver && !isExploding)
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
