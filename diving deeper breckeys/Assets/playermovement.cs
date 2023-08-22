using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public double playerx;
    public double playery = 3;
    public double cameraz = -12;
    public bool faceright = true;
    //  public Vector3 playerpos;
    public Transform player;
    public Transform cameratransform;
    // public int jumptimer;

    [SerializeField] private Transform groundcheck;
    [SerializeField] private Transform roofcheck;
    [SerializeField] private LayerMask groundlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // jumptimer -= 1;
        if (!IsGrounded())
        {
            playery -= 1.5 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerx += 04 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerx -= 04 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) && !IsRoofed())
        {
            playery += 05 * Time.deltaTime;


        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && cameraz < -5)
        {
            cameraz += 0.5;



        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && cameraz > -20)
        {
            cameraz -= 00.5;



        }
        player.position = (new Vector3((float)playerx, (float)playery, 0));
        cameratransform.position = new Vector3((float)playerx, (float)playery, (int)cameraz);

        Flip();



    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.01f, groundlayer);
    }
    private bool IsRoofed()
    {
        return Physics2D.OverlapCircle(roofcheck.position, 0.04f, groundlayer);
    }

    void Flip() 
    { 
    if (Input.GetKeyDown (KeyCode.A) && faceright == true)
        {
            player.localScale = new Vector3(-1, 1, 1);

        }
        if (Input.GetKeyDown(KeyCode.D) && faceright == false)
        {
            player.localScale = new Vector3(-1, 1, 1);

        }
    }

}
