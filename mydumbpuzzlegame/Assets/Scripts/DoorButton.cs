using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public float speed;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
            ButtonDown();
    }

    void ButtonDown()
    {
        //determine endpoint for the transition
        Vector3 pressEndPoint = target.TransformPoint(new Vector3(0, 0, 0));
        
        var step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pressEndPoint, step);
    }
}
