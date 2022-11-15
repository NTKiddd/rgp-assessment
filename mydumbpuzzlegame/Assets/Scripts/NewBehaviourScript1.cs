using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{   
    public float smooth;
    public Transform swingEnd;
    public Transform swingStart;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            Quaternion swing = Quaternion.Euler(0, 0, -45);
            transform.rotation = Quaternion.Slerp(transform.rotation, swing, Time.deltaTime * smooth);
    }

    void Swinging()
    {
        
    }
}
