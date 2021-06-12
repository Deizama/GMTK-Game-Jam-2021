using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour
{
    public GameObject humanCharacter;
    public GameObject ghostCharacter;

    private Transform humanBody;
    private Transform ghostBody;

    public LineRenderer tether;
    private DistanceJoint2D joint;

    // Start is called before the first frame update
    void Start()
    {
        humanBody = humanCharacter.transform;
        ghostBody = ghostCharacter.transform;
    }

    private void Update()
    {
        //"Solidify" Link
        if (Input.GetMouseButtonDown(0))
        {
            StartSwinging();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Input undetected");
            StopSwinging();
        }
        if (joint)
        {
            joint.connectedAnchor = ghostBody.position;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (humanCharacter != null && ghostCharacter != null)
        {
            tether.SetPosition(0, humanCharacter.transform.position);
            tether.SetPosition(1, ghostCharacter.transform.position);
        }
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
