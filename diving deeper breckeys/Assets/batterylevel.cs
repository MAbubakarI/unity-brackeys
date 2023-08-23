using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class batterylevel : MonoBehaviour

{

    public Slider slider;
    public double battery = 100;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        battery -= (double)0.005;
        slider.value = (float)battery;
    }
   
}
