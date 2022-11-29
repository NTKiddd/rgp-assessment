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
    public float pickDistance;
    public bool canJump = true;

    public GameObject mainCamera;
    public GameObject playerHead;
    public GameObject crate;
    public Transform pickUpPosition;
    private GameObject pickUpObject;
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

        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * horizontalInput);

        playerJump();

        Quaternion playerOrientation = new Quaternion(0, mainCamera.transform.rotation.y, 0, mainCamera.transform.rotation.w);
        transform.rotation = playerOrientation;
        
        Debug.DrawRay(playerHead.transform.position, mainCamera.transform.forward * pickDistance);
        
        //pick up object
        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            Ray pickUpRay = new Ray(playerHead.transform.position, mainCamera.transform.forward);
            if (Physics.Raycast(pickUpRay, out hit, pickDistance));
            {   
                if (hit.collider.tag == "Box")
                {
                    //Debug.Log("hit");
                    crate.transform.position = pickUpPosition.position;
                    //crate.transform.position = hit.collider.transform.position;
                }
            }
        } 
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
