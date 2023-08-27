using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        // use this line for instant-rotation
        transform.rotation = targetRotation;
    }
}
