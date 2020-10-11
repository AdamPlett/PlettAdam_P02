using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //mouse sensitivty
    public float mouseSensitivity = 100f;
    //player body
    public Transform playerBody;
    //vertical rotation variable
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //locks and hides cursor upon start of level
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //gets mousemovement according to x and y axis
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        //clamps camera rotation so you can't look past an unrealistic angle
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //rotates camera horizontally
        playerBody.Rotate(Vector3.up * mouseX);
        //rotates camera vertically
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
