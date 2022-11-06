using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public float speed;
    public Transform startTarget;
    public Transform endTarget;
    public bool buttonPress = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player")
            buttonPressDown();
            buttonPress = true;
    }

    private void OnCollisionExit(Collision coli)
    {
        if (coli.gameObject.tag == "Player")
            buttonPressUp();
            buttonPress = false;
    }

    void buttonPressDown()
    {
        Vector3 endPoint = endTarget.TransformPoint(new Vector3(0, 0, 0));
        
        var step = speed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, endPoint, step);
    }

    void buttonPressUp()
    {
        Vector3 startPoint = startTarget.TransformPoint(new Vector3(0, 0, 0));
        
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, startPoint, step);
    }
}
