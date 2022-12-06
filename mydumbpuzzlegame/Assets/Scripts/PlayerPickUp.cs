using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{   
    public GameObject playerHead;
    public GameObject mainCamera;
    public GameObject crate;
    public Transform pickUpPosition;
    public Rigidbody crateRigidbody;

    public float distance = 2f;
    public float height = 0.5f;
    public float pickDistance;
    public float pickUpSpeed;
    private bool pickUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(playerHead.transform.position, mainCamera.transform.forward * pickDistance);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            PickUp();
        }
        else
        {
            crateRigidbody.useGravity = true;
            crateRigidbody.drag = 0.1f;
        }
    }

    void PickUp()
    {   
        RaycastHit hit;
        Ray pickUpRay = new Ray(playerHead.transform.position, mainCamera.transform.forward);
        if (Physics.Raycast(pickUpRay, out hit, pickDistance))
        {   
            if (hit.collider.tag == "Box")
            {
                //Debug.Log("hit");
                crate = hit.collider.transform.parent.gameObject;
                crateRigidbody = hit.collider.transform.parent.GetComponent<Rigidbody>();
                var moveTo = Vector3.Lerp(crate.transform.position, pickUpPosition.position, pickUpSpeed);
                var difference = moveTo - crate.transform.position;
                crateRigidbody.AddForce(difference * 500);
                crate.transform.rotation = pickUpPosition.rotation;
                crateRigidbody.useGravity = false;
                crateRigidbody.drag = 25f;
            }
        }      
    }
}
