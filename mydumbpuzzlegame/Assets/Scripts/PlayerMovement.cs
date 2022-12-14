using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    private float horizontalInput;
    private float verticalInput;
    public float rotationSpeed;
    public bool canJump = true;
    public bool canDoubleJump = false;

    public GameObject mainCamera;
    private Rigidbody Rb;
    private Quaternion playerOrientation;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        //Vector3 playerRotation = new Vector3(0, main Camera.transform.rotation, 0);
    }

    void Update()
    {
        //get input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //var moveVector = new Vector3(horizontalInput, verticalInput, 0);

        //Rb.MovePosition(new Vector3((transform.position.x + moveVector.x * movementSpeed * Time.deltaTime), transform.position.y + moveVector.y * movementSpeed * Time.deltaTime));

        Rb.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * verticalInput);
        Rb.transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * horizontalInput);

        Quaternion playerOrientation = new Quaternion(0, mainCamera.transform.rotation.y, 0, mainCamera.transform.rotation.w);
        transform.rotation = playerOrientation; 

        playerJump();
    }

    private void FixedUpdate() 
    {
    
    }

    void playerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            //add force and push player +y (up) 
            Rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (!canDoubleJump)
        {
            if (collider.gameObject.CompareTag("Floor"))
                canJump = true;
            else if (collider.gameObject.CompareTag("Box"))
                canJump = true;
        }
    }
}
