using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMovement : MonoBehaviour
{
    //  Variable initialized for mouse sensitivity
    [SerializeField]
    int sensitivity;

    //  Variable initialized for player body
    [SerializeField]
    Transform playerBody;

    // Variable initialized for camera movement in y axis
    float yRotationVariable = 0f;

    private void Awake()
    {
        // To lock the cursor in the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        //setting initial camera angle to (0,0,0)
      //------------  transform.localRotation=Quaternion.identity;  //-------------> not workikng
    }
    void Update()
    {
        // Calling mouse movement function 
        mousemover();
    }
    private void mousemover()
    {
        // Getting movement of mouse in x axis and multiplying with sensitivity
        float mousex = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        // Rotating player body according to the mouse movement in x axis
         playerBody.Rotate(Vector3.up * mousex, Space.World);

        // Getting movement of mouse in y axis and multiplying with sensitivity
        float mousey = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Mouse movement is in opposite direction with respect to camera, so to make them in same direction  
        yRotationVariable -= mousey;

        // Clamping the camera for y axis with in -90 degree to 90 degree
        yRotationVariable = Mathf.Clamp(yRotationVariable, -90f, 90f);

        // Rotating camera according to the mouse movement in y axis
        transform.localEulerAngles = Vector3.right * yRotationVariable;
    }
}
