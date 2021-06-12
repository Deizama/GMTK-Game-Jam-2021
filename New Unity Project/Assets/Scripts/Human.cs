using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public Transform humanBody;
    public Transform ghostBody;
    Rigidbody2D rb;
    public float Speed;
    public bool IsGrounded;
    public float JumpForce;
    public GameObject FootR;
    public GameObject FootL;
    private DistanceJoint2D joint;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Walk
        float x = Input.GetAxis("Horizontal") * Speed * 0.1f;

        humanBody.Translate(Vector3.right * x);

        //Jump
        RaycastHit2D hitL = Physics2D.Raycast(FootL.transform.position, -Vector2.up, 0.1f);
        RaycastHit2D hitR = Physics2D.Raycast(FootR.transform.position, -Vector2.up, 0.1f);

        if (hitL || hitR)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(Vector2.up * JumpForce);
        }


    }
}