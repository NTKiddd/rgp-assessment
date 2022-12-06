using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    //public Transform cameraTarget;
    public GameObject mainCamera;
    public GameObject aimCamera;
    public GameObject aimReticle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            mainCamera.SetActive(false);
            aimCamera.SetActive(true);
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            mainCamera.SetActive(true);
            aimCamera.SetActive(false);
        }
    }
}
