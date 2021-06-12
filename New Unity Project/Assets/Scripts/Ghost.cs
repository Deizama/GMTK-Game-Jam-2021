using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float mouseSensitivity;

    public Transform playerBody;

    public Transform humanBody;

    private Vector2 mousePoint;

    // Start is called before the first frame update
    void Start()
    {
        //Vector2 mousePoint = Input.mousePosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector2.Distance(this.gameObject.transform.position, humanBody.transform.position);
        float stopX = 1f;
        float stopY = 1f;

        if (Input.GetMouseButtonDown(0))
        {
            stopX = 0f;
            stopY = 0f;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (this.gameObject.transform.position.x - humanBody.transform.position.x > 5) { if (Input.GetAxis("Mouse X") > 0) { stopX = 0f; } }
        else if (humanBody.transform.position.x - this.gameObject.transform.position.x > 5) { if (Input.GetAxis("Mouse X") < 0) { stopX = 0f; } }

        if (this.gameObject.transform.position.y - humanBody.transform.position.y > 4) { if (Input.GetAxis("Mouse Y") > 0) { stopY = 0f; } }
        else if (humanBody.transform.position.y - this.gameObject.transform.position.y > 4) { if (Input.GetAxis("Mouse Y") < 0) { stopY = 0f; } }
       
        if (distance > 7)
        {
            if (this.gameObject.transform.position.x - humanBody.transform.position.x > 5) { mouseX = -(distance/ 50); }
            else if (humanBody.transform.position.x - this.gameObject.transform.position.x > 5) { mouseX = (distance / 50); }

            if (this.gameObject.transform.position.y - humanBody.transform.position.y > 4) { mouseY = -(distance / 50); }
            else if (humanBody.transform.position.y - this.gameObject.transform.position.y > 4)  { mouseY = (distance / 50); }
        }
        mouseX = mouseX * stopX;
        mouseY = mouseY * stopY;

        playerBody.Translate(Vector3.up * mouseY);
        playerBody.Translate(Vector3.right * mouseX);

    }
}
