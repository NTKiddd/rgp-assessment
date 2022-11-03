using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    private float horizontalInput;
    private float verticalInput;
    public bool canJump = true;

    private Rigidbody Rb;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //get input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * horizontalInput);

        playerJump();
    }

    private void FixedUpdate() 
    {

    }

    void playerJump()
    {
        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            //add force and push player +y (up) 
            Rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }
    }
}
