using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class batterylevel : MonoBehaviour

{

    public UnityEngine.UI.Slider  slider;
    public double battery = 100;
    public GameObject gamepanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (battery <= 0) { gamepanel.SetActive(true); }
        else
        { battery -= (double)0.005; }
        slider.value = (float)battery;
        
    }
   
}
