using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamCon : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 1000f;
   // [SerializeField] private Transform cameraTransform;

    [SerializeField] private Vector2 xClamp = new Vector2(-90f, 90f);
    [SerializeField] private Vector2 yClamp = new Vector2(-90f, 90f);

    [SerializeField] private float xRotation = 0f;
    [SerializeField] private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, xClamp.x, xClamp.y);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, yClamp.x, yClamp.y);

        //cameraTransform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}

