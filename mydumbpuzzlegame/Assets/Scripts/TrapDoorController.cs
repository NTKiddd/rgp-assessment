using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorController : MonoBehaviour
{
    public GameObject leftTrapdoorPivot;
    public GameObject rightTrapdoorPivot;
    public GameObject trapdoorButton;

    public Transform leftStart;
    public Transform leftEnd;
    public Transform rightStart;
    public Transform rightEnd;
    
    public float openSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            trapdoorClose();
        }
    }

    private void OnCollisionStay(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            trapdoorOpen();
        }
        else if (other.gameObject.tag != "Player")
        {
            trapdoorClose();
        }
    }

    void trapdoorOpen()
    {
        leftTrapdoorPivot.transform.rotation = Quaternion.RotateTowards(leftTrapdoorPivot.transform.rotation, leftEnd.rotation, openSpeed * Time.deltaTime);
        rightTrapdoorPivot.transform.rotation = Quaternion.RotateTowards(rightTrapdoorPivot.transform.rotation, rightEnd.rotation, openSpeed * Time.deltaTime);
    }

    void trapdoorClose()
    {
        leftTrapdoorPivot.transform.rotation = Quaternion.RotateTowards(leftTrapdoorPivot.transform.rotation, leftStart.rotation, openSpeed * Time.deltaTime);
        rightTrapdoorPivot.transform.rotation = Quaternion.RotateTowards(rightTrapdoorPivot.transform.rotation, rightStart.rotation, openSpeed * Time.deltaTime);
    }
}
