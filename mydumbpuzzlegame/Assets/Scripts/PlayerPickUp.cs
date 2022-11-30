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

    public float pickDistance;
    public float pickUpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(playerHead.transform.position, mainCamera.transform.forward * pickDistance);
        
        if (Input.GetKey(KeyCode.E))
        {
            PickUp();
        }
        else
        {
            crateRigidbody.useGravity = true;
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
                hit.collider.transform.position = Vector3.Lerp(crate.transform.position, pickUpPosition.position, pickUpSpeed);
                //hit.collider.transform.rotation = pickUpPosition.rotation;
                //crateRigidbody.useGravity = false;
            }
        }      
    }
}
