using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    //public Transform cameraTarget;
    public float rotationLerp;
    public float positionLerp;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, cameraTarget.position, positionLerp);
        //transform.rotation = Quaternion.Lerp(transform.rotation, cameraTarget.rotation, positionLerp);
    }
}
