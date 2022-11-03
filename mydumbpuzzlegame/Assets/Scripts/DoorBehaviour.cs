using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public float speed;
    public Transform endTarget;
    public Transform startTarget;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {   
            DoorOpen();
        }
        else 
        {
            DoorClose();
        }
    }

    void DoorOpen()
    {
        //determine endpoint for the transition
        Vector3 endPoint = endTarget.TransformPoint(new Vector3(0, 0, 0));
        
        var step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPoint, step);
    }

    void DoorClose()
    {
        Vector3 startPoint = startTarget.TransformPoint(new Vector3(0, 0, 0));
        
        var step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, startPoint, step);
    }
}
