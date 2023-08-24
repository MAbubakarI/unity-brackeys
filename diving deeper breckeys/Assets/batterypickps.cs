using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class batterypickps : MonoBehaviour
{
    batterylevel neededscript;
    // public Transform batterycheck;
    // public Transform batterycheckone;
    // public Transform batterychecktwo;
    // [Serialize] public LayerMask batterylayer;

    // private bool IsBattery()
    // {
    //     return Physics2D.OverlapCircle(batterycheck.position, 0.01f, batterylayer);
    // }
    // Start is called before the first frame update
    void Start()
    {
        neededscript = GameObject.FindGameObjectWithTag("Collectable").GetComponent<batterylevel>();
    }

    // Update is called once per frame
    void Update()
    {

        //  if(IsBattery())
        // {

        //     Debug.Log("collision detected");
        //  neededscript.AddBattery();
        // }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Battery"))
        {
            Destroy(other.gameObject);
            neededscript.AddBattery();



        }

    }










}
