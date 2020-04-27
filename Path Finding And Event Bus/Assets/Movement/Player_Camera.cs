using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour {

    // Contains the Player object's position
    public Transform player;

    // A vector that determines the offset of the camera that can be edited in the Unity Inspector
    public Vector3 offset;

    private const float Y_ANGLE_MIN = 17f;
    private const float Y_ANGLE_MAX = 17f;

    private const float X_ANGLE_MIN = -100f;
    private const float X_ANGLE_MAX = 100f;


    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    public float distance = 3;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }
    private void Update()
    {
        //currentX += Input.GetAxis("Mouse X");
        //currentY += Input.GetAxis("Mouse Y");

        //currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        //currentX = Mathf.Clamp(currentX, X_ANGLE_MIN, X_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        transform.position = player.position + offset;
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * offset;
        camTransform.LookAt(lookAt.position);
    }
    // Update is called once per frame
    //void Update () {

    //       // Applies the Player object's position to the Main camera, which is then offset with the offset Vector3
    //       transform.position = player.position + offset;

    //}   
}
