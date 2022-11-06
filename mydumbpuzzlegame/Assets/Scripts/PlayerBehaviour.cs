using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    private float horizontalInput;
    private float verticalInput;
    public float rotationSpeed;
    public bool canJump = true;

    public GameObject mainCamera;
    private Rigidbody Rb;
    private Quaternion playerOrientation;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        //Vector3 playerRotation = new Vector3(0, mainCamera.transform.rotation, 0);
    }

    void Update()
    {
        //get input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * horizontalInput);

        playerJump();

        Quaternion playerOrientation = new Quaternion(0, mainCamera.transform.rotation.y, 0, mainCamera.transform.rotation.w);
        transform.rotation = playerOrientation;
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
