using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Target of the camera
    public Transform humanPlayer;

    private Transform cameraTansform;

    // offset between camera and target
    public Vector3 Offset;
    // change this value to get desired smoothness
    public float SmoothTime = 0.3f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector2 velocity = Vector2.zero;

    private void Start()
    {
        cameraTansform = this.gameObject.transform;
    } 

    private void LateUpdate()
    {
        // update position
        
        cameraTansform.position = Vector2.SmoothDamp(cameraTansform.position, humanPlayer.position, ref velocity, SmoothTime, 25f);
        cameraTansform.position = cameraTansform.position + Offset;
    }
}
