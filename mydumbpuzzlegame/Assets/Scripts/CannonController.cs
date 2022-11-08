using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Rigidbody cannonBall;
    private Vector3 cannonSpawn;
    public float shootForce;
    public bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cannonShooting());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !canShoot)
            canShoot = true;
        else if (Input.GetKeyDown(KeyCode.R) && canShoot)
            canShoot = false;
    }

    IEnumerator cannonShooting()
    {   
        while (canShoot)
        {
            Rigidbody cannonShot = Instantiate(cannonBall, this.transform.position, this.transform.rotation);
            cannonShot.AddRelativeForce(Vector3.right * shootForce);
            Destroy(cannonShot.gameObject, 5);
            yield return new WaitForSeconds(2.5f);
        }
    }
}
