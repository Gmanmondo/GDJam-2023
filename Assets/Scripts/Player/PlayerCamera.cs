using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotate;
    float yRotate;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotate += mouseX;

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotate, yRotate, 0);
        orientation.rotation = Quaternion.Euler(0, yRotate, 0);
    }
}
