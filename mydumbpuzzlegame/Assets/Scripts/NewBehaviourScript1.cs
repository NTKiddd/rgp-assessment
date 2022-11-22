using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{   
    public float smooth;
    public bool swingToLeft;
    public bool swingToRight;

    // Start is called before the first frame update
    void Start()
    {
        swingToRight = true;
        swingToLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        Swinging();
    }

    void Swinging()
    {
        Quaternion swingRight = Quaternion.Euler(0, 0, 45);
        Quaternion swingLeft = Quaternion.Euler(0, 0, -45);
        
        if (transform.rotation.z > 44)
        {
            swingToRight = false;
            swingToLeft = true;
        }

        if (transform.rotation.z < -44)
        {
            swingToRight = true;
            swingToLeft = false;
        } 

        if(swingToRight)
            transform.rotation = Quaternion.Slerp(transform.rotation, swingRight, Time.deltaTime * smooth);

        if (swingToLeft)
            transform.rotation = Quaternion.Slerp(transform.rotation, swingLeft, Time.deltaTime * smooth); 
    }
}
