using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public Transform humanBody;
    Rigidbody2D rb;
    public float JumpY;
    public float JumpX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if (humanBody.position.x < gameObject.transform.position.x)
            {
                rb.AddForce(Vector2.up*JumpY);
                rb.AddForce(Vector2.left*JumpX);
            }
            else if (humanBody.position.x > gameObject.transform.position.x)
            {
                rb.AddForce(Vector2.up*JumpY);
                rb.AddForce(Vector2.right*JumpX);
            }
        }
    }

}