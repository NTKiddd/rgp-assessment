using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Rigidbody cannonBall;
    public GameObject cannonSpawner;
    private Vector3 cannonSpawn;

    // Start is called before the first frame update
    void Start()
    {
        cannonSpawn = new Vector3(cannonSpawner.transform.position.x, cannonSpawner.transform.position.y, cannonSpawner.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            cannonShooting();
        }
    }

    void cannonShooting()
    {
        Rigidbody cannonShot = Instantiate(cannonBall, this.transform.position, this.transform.rotation);
    }
}
