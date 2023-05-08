using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Animations : MonoBehaviour
{
    public Points pointsScript;
    public int points;
    private Animator anim;
 
    // Start is called before the first frame update
    void Start()
    {
        pointsScript = GameObject.Find("EventSystem").GetComponent<Points>();
        points = pointsScript.puntos;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         points = pointsScript.puntos;

        if (points >= 30)
        {
            anim.SetTrigger("Alert");
        }
        if (points >= 50)
        {
            anim.SetTrigger("Stand");
            anim.SetTrigger("Idle");
        }
        if (points >= 125)
        {
            anim.SetTrigger("Terrified");
            anim.SetTrigger("Stand");
            anim.SetTrigger("Idle");
        }
        if (points >= 280)
        {
         
            anim.SetTrigger("Terrified");
            anim.SetTrigger("Stand");
            anim.SetTrigger("Idle");
            anim.SetTrigger("RunTurn");
        }
        if (points >= 475)
        {
            anim.SetTrigger("Terrified");
            anim.SetTrigger("Stand");
            anim.SetTrigger("Idle");
            anim.SetTrigger("RunTurn");
            anim.SetTrigger("Running");
        }

    }
}
