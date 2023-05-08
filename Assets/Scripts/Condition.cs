using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public Text txt;
    public Text Btxt;
    public Button but;
    public Text Btxtmenu;
    public Button butmenu;
    public Image[] img;
    public Points pnts;
    public float timer;
    public int[] stars;
    bool countdown = true;
    public AkEvent win;
    public AkEvent lose;
    public AkEvent stopGameplayMusic;

    private void Start()
    {
        pnts = FindFirstObjectByType<Points>();
        img[0].gameObject.SetActive(false);
        img[1].gameObject.SetActive(false);
        img[2].gameObject.SetActive(false);
        but.gameObject.SetActive(false);
        butmenu.gameObject.SetActive(false);
        Btxt.enabled= false;
    }

    void Update()
    {
        if (countdown)
        {
            timer -= Time.deltaTime;
        }
        
        txt.text = timer.ToString("F0");

        if (timer <= 0)
        {
            Btxt.enabled = true;
            countdown = false;
            butmenu.gameObject.SetActive(true);
            but.gameObject.SetActive(true);
            Btxt.text = "Se acabo el tiempo";
            lose.enabled = true;
            win.enabled = false;
            stopGameplayMusic.enabled = true;
        }

        if (pnts.puntos >= stars[0] && timer <= 0)
        {
            Btxt.enabled = true;
            img[0].gameObject.SetActive(true);
            lose.enabled = true;
            win.enabled = false;
            stopGameplayMusic.enabled = true;
        }
        if (pnts.puntos >= stars[1] && timer <= 0)
        {
            Btxt.enabled = true;
            img[1].gameObject.SetActive(true);
            lose.enabled = true;
            win.enabled = false;
            stopGameplayMusic.enabled = true;
        }

        if (pnts.puntos >= stars[2])
        {
            Btxt.enabled = true;
            img[0].gameObject.SetActive(true);
            img[1].gameObject.SetActive(true);
            img[2].gameObject.SetActive(true);
            lose.enabled = false;
            win.enabled = true;
            stopGameplayMusic.enabled = true;
            countdown = false;
            but.gameObject.SetActive(true);
            butmenu.gameObject.SetActive(true);
            Btxt.text = "GANASTE!!!";
        }
    }
}
