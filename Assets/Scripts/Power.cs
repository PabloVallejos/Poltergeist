using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public Text txt;
    public Slider sld;
    public int limit; //Limite de energía
    public float pwr; //Energía actual

    private void Start()
    {
        sld = FindObjectOfType<Slider>();
        sld.maxValue = limit;
    }

    private void Update()
    {
        txt.text = "Power: " + pwr;
        sld.value = pwr;

        //Carga de energía
        if (pwr < limit)
        {
            pwr += Time.deltaTime / 2;
        }
    }

}
