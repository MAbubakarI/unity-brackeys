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
    public int maxhp;
    public Gradient gradient;
    public UnityEngine.UI.Image fill;
    public int carryweight = 6;
    public playermovement playermovement;
  

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
     //   if (buttonclick == false)
        {
            peaceful = true;
            currentdiff.text = "Peaceful";
            diffsel = true;
        }
        carryweight = 15;
        buttonclick = true;



    }
    public void Easy()
    {
//if (buttonclick == false)
        {
            battery = 1000;
            currentdiff.text = "Easy";
            diffsel = true;
            slider.maxValue = 1000;
            peaceful = false;
        }
        carryweight = 8;
        buttonclick = true;

    }
    public void Medium()
    {
      //  if (buttonclick == false)
        {
            battery = 400;
            slider.maxValue = 400;
            currentdiff.text = "Medium";
            diffsel = true;
            peaceful = false;
        }
        carryweight = 6;
        buttonclick = true;

    }
    public void HardCore()
    {
        
//if (buttonclick == false)
        {
            peaceful = false;
            battery = 200;
            slider.maxValue = 200;
            currentdiff.text = "Hardcore";
            diffsel = true;
        }
        carryweight = 4;
        buttonclick = true;

    }
    public void ResetDiff() 
    {
        buttonclick = false;
        peaceful = false;
        currentdiff.text = "None";
        diffsel = false;

    }
    public void AddBattery() 
    {
    if (currentdiff.text == "Easy")
        {
            battery += 300;


        }
        else if (currentdiff.text == "Medium")
        {
            battery += 150;

        }
        else if (currentdiff.text == "Hardcore")
        {
            battery += 75;

        }


    }
    public void StartGame() 
    {
        if (diffsel == true) startpanel.SetActive(false);
        playermovement.carryweight = carryweight;
    }

    // Start is called before the first frame update
    void Start()
    {
        paused = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (battery <= 0) 
        { gamepanel.SetActive(true); }
      //  else if (diffsel == true){ battery =}
        else if (battery>0 && paused == false && peaceful == false)
        { battery -= (double)0.005; }

        slider.value = (float)battery;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        //if (IsBattery())
        {
          //  AddBattery();


        }
        
    }
   
}
