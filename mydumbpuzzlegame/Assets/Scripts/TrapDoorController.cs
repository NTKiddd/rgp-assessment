using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorController : MonoBehaviour
{
    public GameObject leftTrapdoorPivot;
    public GameObject rightTrapdoorPivot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            leftTrapdoorOpen();
            rightTrapdoorOpen();
        }
    }

    void leftTrapdoorOpen()
    {
        leftTrapdoorPivot.transform.eulerAngles = new Vector3 (0, 0 ,-90);
    }

    void rightTrapdoorOpen()
    {
        rightTrapdoorPivot.transform.eulerAngles = new Vector3 (0, 0 ,90);
    }
}
