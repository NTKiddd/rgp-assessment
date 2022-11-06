using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float speed;
    public Transform endTarget;
    public Transform startTarget;
    private Vector3 velocity = Vector3.zero;
    private DoorButton buttonScript;
    private GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Button");
        buttonScript = button.GetComponent<DoorButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonScript.buttonPress)
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
