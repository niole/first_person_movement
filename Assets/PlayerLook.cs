using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    public Transform playerBody;

    private float xRotation = 0f;

    public float mouseSensitivity = 100f;

    void Start()
    {

        //lock cursor to center screen
        // so can't click outside of window
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = NormalizeMousePoint(Input.GetAxis("Mouse X"));
        float mouseY = NormalizeMousePoint(Input.GetAxis("Mouse Y"));

        // only allow to rotate so much
        // make so can't look behind us
        xRotation = Mathf.Clamp(xRotation - mouseY, -90f, 90f);
        // then apply the y rotation to the player, side to side rotation
        playerBody.Rotate(Vector3.up * mouseX);

        // apply rotation around the x axis to the camera (the reference of this)
        // up down rotation
        // don't want to rotate the player body up and down, that would be wierd
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    float NormalizeMousePoint(float point)
    {
        return point * mouseSensitivity * Time.deltaTime;
    }
}
