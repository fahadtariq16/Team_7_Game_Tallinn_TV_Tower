using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 120f;
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        //locks the cursor in, so it won't leave the game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //look controls, updates the coordinates based on mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        //clamps the vertical look to prevent flipping
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

