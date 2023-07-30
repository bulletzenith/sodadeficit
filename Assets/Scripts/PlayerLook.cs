using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensitivityX = 400;
    public float sensitivityY = 400;

    float sensX;
    float sensY;

    float velocity = 0f;
    float smoothTime = 0.1f;

    public float fov = 90f;

    public Transform orientation;
    public Camera cam;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        sensX = sensitivityX;
        sensY = sensitivityY;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate camera and player 
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        // field of view change/zoom from keypress
        if (Input.GetKey("c"))
        {
            cam.fieldOfView = fov / 3;
            //cam.fieldOfView = Mathf.SmoothDamp(cam.fieldOfView, fov, ref velocity, 0.25f);
            sensX = sensitivityX / 2;
            sensY = sensitivityY / 2;
        }
        else
        {
            cam.fieldOfView = fov;
            sensX = sensitivityX;
            sensY = sensitivityY;
        }
    }
}
