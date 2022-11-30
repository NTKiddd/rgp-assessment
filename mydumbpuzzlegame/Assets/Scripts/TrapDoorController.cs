using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorController : MonoBehaviour
{
    public GameObject leftTrapdoorPivot;
    public GameObject rightTrapdoorPivot;
    public GameObject trapdoorButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.name == "PlayerMesh")
        {
            trapdoorOpen();
        }
    }

    void trapdoorOpen()
    {
        leftTrapdoorPivot.transform.eulerAngles = new Vector3 (0, 0 ,-90);
        rightTrapdoorPivot.transform.eulerAngles = new Vector3 (0, 0 ,90);
    }
}
