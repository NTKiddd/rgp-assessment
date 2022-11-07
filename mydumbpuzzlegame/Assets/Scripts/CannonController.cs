using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Rigidbody cannonBall;
    private Vector3 cannonSpawn;
    public float shootForce;
    public bool canShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < 20; i++)
            {
                StartCoroutine(cannonShooting());
            }
        }
    }

    IEnumerator cannonShooting()
    {   
        yield return new WaitForSeconds(5);
        Rigidbody cannonShot = Instantiate(cannonBall, this.transform.position, this.transform.rotation);
        cannonShot.AddRelativeForce(Vector3.right * shootForce);
        //yield return new WaitForSeconds(10);
    }
}
