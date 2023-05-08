using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public Text txt;
    public Slider sld;
    public int limit; //Limite de energ�a
    public float pwr; //Energ�a actual

    private void Start()
    {
        sld = FindObjectOfType<Slider>();
        sld.maxValue = limit;
    }

    private void Update()
    {
        txt.text = "Power: " + pwr;
        sld.value = pwr;

        //Carga de energ�a
        if (pwr < limit)
        {
            pwr += Time.deltaTime / 2;
        }
    }

}
