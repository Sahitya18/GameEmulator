using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    // Variable is initialized for camera
    [SerializeField]
     Transform camera;

    // Variable is initialized for speed of character
    [SerializeField]
    float speed;
    private void Awake()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Character movement function is called
        movement();
        jump();

    }
    protected void movement()
    {
        // Getting input form keys ("W", "S", "A", "D")
        // Changing position of object with repect to the direction of camera 
        if (Input.GetKey(KeyCode.W))  // "W"-> Forward
            transform.position += camera.transform.forward * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S)) // "S"-> Backward
            transform.position -= camera.transform.forward * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.A)) // "A"-> Left
            transform.position -= camera.transform.right * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.D)) // "D"-> Right
            transform.position += camera.transform.right * speed * Time.deltaTime;
    }

    bool inair = false;
    public int jumpY;
    [SerializeField]
    new Rigidbody rigidbody;

    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !inair)
        {
            print("enter");
            rigidbody.velocity = Vector3.up * jumpY;
            inair = true;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            inair = false;
        }
    }
}
