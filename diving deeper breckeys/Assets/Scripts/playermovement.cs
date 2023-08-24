using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public double playerx;
    public double playery;
    public double cameraz = -12;
    public bool faceright = true;
    //  public Vector3 playerpos;
    public Transform player;
    public Transform cameratransform;
    // public int jumptimer;

    [SerializeField] private Transform groundcheck;
    [SerializeField] private Transform roofcheck;
    public Transform allplayer;
    public Transform sidecheck;
    public Transform sidecheckone;
    public Transform sidechecktwo;
    public Transform leftcheck;
    public Transform leftcheckone;
    public Transform leftchecktwo;
    public batterylevel neededscript;
    public TMP_Text scoretext;
    public TMP_Text endscore;


    [SerializeField] private LayerMask groundlayer;

    bool canInteract = false;
    GameObject collref;
    public Stack<GameObject> carry = new Stack<GameObject>();
    GameObject drop;
    public int carryWeight;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //    allplayer.position = (new Vector3(0, 10, 0));
        //     cameratransform.position = (new Vector3(0, 10, -15));
        carryWeight = neededscript.carryweight;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canInteract)
            {
                carry.Push(collref);

                collref.GetComponent<Rigidbody2D>().isKinematic = false;
                collref.GetComponent<CircleCollider2D>().enabled = false;
                collref.GetComponent<SpringJoint2D>().connectedBody = rb;
                collref.GetComponent<SpringJoint2D>().enabled = true;
                canInteract = false;
            }
            else if (!canInteract && carry.Count > 0)
            {
                drop = carry.Pop();

                Rigidbody2D droprb = drop.GetComponent<Rigidbody2D>();
                droprb.isKinematic = true;
                droprb.velocity = Vector3.zero;
                droprb.angularVelocity = 0;
                drop.GetComponent<CircleCollider2D>().enabled = true;
                drop.GetComponent<SpringJoint2D>().enabled = false;
            }
        }

        // jumptimer -= 1;
        if (!IsGrounded()) playery -= 2.25 * Time.deltaTime * Math.Max(1, (carry.Count - carryWeight + 2));
        if (Input.GetKey(KeyCode.D) && !IsRightone() && !IsRighttwo() && !IsRightthree()) playerx += 04 * Time.deltaTime / Math.Max(1, (carry.Count - carryWeight + 2));
        if (Input.GetKey(KeyCode.A) && !IsLeftone() && !IsLefttwo() && !IsLeftThree()) playerx -= 04 * Time.deltaTime / Math.Max(1, (carry.Count - carryWeight + 2));
        if (Input.GetKey(KeyCode.W) && !IsRoofed()) playery += 05 * Time.deltaTime / Math.Max(1, (carry.Count - carryWeight + 2));
        Debug.Log(Math.Max(1, (carry.Count - carryWeight + 2)));

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && cameraz < -5) cameraz += 0.5;
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && cameraz > -20) cameraz -= 00.5;

        allplayer.position = (new Vector3((float)playerx, (float)playery, 0));
        cameratransform.position = new Vector3((float)playerx, (float)playery, (int)cameraz);
        Flip();

        scoretext.text = score.ToString();
        endscore.text = score.ToString();
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.01f, groundlayer);
    }
    private bool IsRoofed()
    {
        return Physics2D.OverlapCircle(roofcheck.position, 0.04f, groundlayer);
    }
    private bool IsRightone()
    {
        return Physics2D.OverlapCircle(sidecheck.position, 0.04f, groundlayer);
    }
    private bool IsRighttwo()
    {
        return Physics2D.OverlapCircle(sidecheckone.position, 0.04f, groundlayer);
    }
    private bool IsRightthree()
    {
        return Physics2D.OverlapCircle(sidechecktwo.position, 0.04f, groundlayer);
    }
    private bool IsLeftone()
    {
        return Physics2D.OverlapCircle(leftcheck.position, 0.04f, groundlayer);
    }
    private bool IsLefttwo()
    {
        return Physics2D.OverlapCircle(leftcheckone.position, 0.04f, groundlayer);
    }
    private bool IsLeftThree()
    {
        return Physics2D.OverlapCircle(leftchecktwo.position, 0.04f, groundlayer);
    }

    void Flip()
    {
        if (Input.GetKeyDown(KeyCode.A) && faceright == true) player.localScale = new Vector3(-1, 1, 1);
        if (Input.GetKeyDown(KeyCode.D) && faceright == false) player.localScale = new Vector3(-1, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + " : " + collision.gameObject.tag);
        if (collision.gameObject.tag.Split()[0] == "Collectable")
        {
            collref = collision.gameObject;
            canInteract = true;
        }
        else if (collision.gameObject.tag == "Score")
        {
            while (carry.Count > 0)
            {
                drop = carry.Pop();
                score += int.Parse(drop.tag.Split('/')[1]);
                Destroy(drop);
                Debug.Log(score);
            }
        }

        else if (collision.gameObject.tag == "Battery")
        {
            Destroy(collision.gameObject);
            neededscript.AddBattery();

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Split()[0] == "Collectable") canInteract = false;
    }
}

