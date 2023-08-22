using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public double playerx = 0;
    public double playery;
    public int playerz;
    public bool faceright = true;
    //  public Vector3 playerpos;
    public Transform player;
    // public int jumptimer;

    [SerializeField] private Transform groundcheck;
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
            playery -= 0.01;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerx += 0.1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerx -= 0.1;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            playery += 0.05;


        }
        player.position = (new Vector3((float)playerx, (float)playery, playerz));

        Flip();



    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.01f, groundlayer);
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
