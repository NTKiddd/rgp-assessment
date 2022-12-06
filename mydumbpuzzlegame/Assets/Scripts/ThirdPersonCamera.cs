using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonCamera : MonoBehaviour
{
    //public Transform cameraTarget;
    public GameObject mainCamera;
    public GameObject aimCamera;
    public GameObject aimReticle;
    public GameObject player;
    //public Cinemachine.AxisState xAxis;
    //public Cinemachine.AxisState yAxis;

    public CinemachineFreeLook cinemachineFreeLook;

    // Start is called before the first frame update
    void Start()
    {
        //cinemachineFreeLook = gameObject.AddComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            //mainCamera.SetActive(false);
            //aimCamera.SetActive(true);
            cinemachineFreeLook.Follow = aimCamera.transform;
            cinemachineFreeLook.LookAt = aimCamera.transform;
            //cinemachineFreeLook.
        }
        else if (Input.GetMouseButtonUp(1))
        {
            cinemachineFreeLook.Follow = player.transform;
            cinemachineFreeLook.LookAt = player.transform;
        }
    }
}
