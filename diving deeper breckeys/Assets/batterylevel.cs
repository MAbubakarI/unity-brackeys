using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;
using TMPro;

public class batterylevel : MonoBehaviour

{

    public UnityEngine.UI.Slider  slider;
    public double battery = 100;
    public GameObject gamepanel;
    public bool paused = true;
    public bool peaceful = false;
    public bool buttonclick = false;
    public TMP_Text currentdiff;
    public bool diffsel;
    public GameObject startpanel;

    public void SetPaused()
    {
        paused = true;

    }
    public void SetUnPaused()
    {
        if (diffsel == true)
        {
            paused = false;
        }

    }
    public void Peaceful()
    {
        if (buttonclick == false)
        {
            peaceful = true;
            currentdiff.text = "Peaceful";
            diffsel = true;
        }
        buttonclick = true;



    }
    public void Easy()
    {
        if (buttonclick == false)
        {
            battery = 1000;
            currentdiff.text = "Easy";
            diffsel = true;
        }
        buttonclick = true;

    }
    public void Medium()
    {
        if (buttonclick == false)
        {
            battery = 400;
            currentdiff.text = "Medium";
            diffsel = true;
        }
        buttonclick = true;

    }
    public void HardCore()
    {
        if (buttonclick == false)
        {
            battery = 200;
            currentdiff.text = "Hardcore";
            diffsel = true;
        }
        buttonclick = true;

    }
    public void ResetDiff() 
    {
        buttonclick = false;
        peaceful = false;
        currentdiff.text = "None";
        diffsel = false;

    }
    public void StartGame() 
    {
    if (diffsel == true)
        {
            startpanel.SetActive(false);


        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (battery <= 0) 
        { gamepanel.SetActive(true); }
        else if (battery>0 && paused == false && peaceful == false)
        { battery -= (double)0.005; }
        slider.value = (float)battery;
        
    }
   
}
