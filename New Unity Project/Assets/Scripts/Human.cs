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

    public int health = 3;
    private DistanceJoint2D joint;

    public Transform checkpoint;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(Vector2.up * JumpForce);
        }
    }

    void FixedUpdate()
    {
        //Walk
        float x = Input.GetAxis("Horizontal") * Speed * 0.1f;

        humanBody.Translate(Vector3.right * x);

        //Jump
        RaycastHit2D hitL = Physics2D.Raycast(FootL.transform.position, -Vector2.up, 0.2f);
        RaycastHit2D hitR = Physics2D.Raycast(FootR.transform.position, -Vector2.up, 0.2f);

        if (hitL || hitR)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }

    }

    public void LosingHealth (int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            health = 3;
            humanBody.position = checkpoint.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // layer 10 = checkpoint
        if (collision.gameObject.layer == 10)
        {
            checkpoint = collision.transform;
        }
    }
}