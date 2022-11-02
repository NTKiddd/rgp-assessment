using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    private float horizontalInput;
    private float verticalInput;
    private bool canJump;

    private Rigidbody Rb;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //get input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * horizontalInput);

        if (canJump)
            playerJump();
    }

    void playerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //add force and push player +y (up) 
            Rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
            canJump == true;
    }
}
