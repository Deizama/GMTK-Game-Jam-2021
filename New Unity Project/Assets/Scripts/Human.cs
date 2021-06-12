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
        float x = Input.GetAxis ("Horizontal") * Speed * 0.1f;
        
        humanBody.Translate(Vector3.right * x);

    //Jump
        IsGrounded = Physics2D.OverlapArea(FootR.transform.position, FootL.transform.position);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(Vector2.up*JumpForce);
        }
    //"Solidify" Link
        if(Input.GetMouseButtonDown(0))
        {
            StartSwinging();
        }
        if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("Input undetected");
            StopSwinging();
        }

    void StartSwinging()
        {   
            Debug.Log("Void entered");
            //RaycastHit hit;

            //Configuring the joint that links the human and the ghost
            joint = humanBody.gameObject.AddComponent<DistanceJoint2D>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = ghostBody.position;

            //Configuring the max and min distance of the link during the "swinging"
            float distanceFromGhost = Vector2.Distance(humanBody.position, ghostBody.position);
            
            joint.autoConfigureDistance = false;
            joint.distance = distanceFromGhost;
            joint.maxDistanceOnly = true;
            joint.enableCollision = true;
            //joint.minDistance = distanceFromGhost * 0f;

            //joint.spring = 4.5f;
            //joint.damper = 7f;
            //joint.massScale = 4.5f;

            Debug.Log("Raycast Done");
            
        }
    void StopSwinging()
    {
        Destroy(joint);
    }

    }



}
