using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float mouseSensitivity;

    public Transform playerBody;

    private Vector2 mousePoint;

    // Start is called before the first frame update
    void Start()
    {
        //Vector2 mousePoint = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        playerBody.Translate(Vector3.up * mouseY);
        playerBody.Translate(Vector3.right * mouseX);
    }
}
