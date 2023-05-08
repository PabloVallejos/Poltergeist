using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text txt; //Texto de los puntos
    public int curr;
    public int puntos;
    int prev;
    bool combo = false; //Para activar el combo

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 significa el boton izquierdo del mouse
        {
            if (puntos > 0)
            {
                puntos -= 5;
            }
        }
        //Muestra los puntos
        txt.text = "Puntos: " + puntos;

        //Activa el combo
        if (prev < curr + 1)
        {
            combo = true;
            prev = curr;
        }

        //Desactiva el combo
        if (curr < prev || curr >= prev + 2)
        {
            combo = false;
            curr = 0;
        }
    }

    //Suma puntos
    public void PointUp(int i)
    {
        //Multiplicador de puntos
        if (combo == true)
        {
            puntos += i * curr;
        }
            puntos += i;
    }
    
}
