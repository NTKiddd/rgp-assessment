using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PortalController : MonoBehaviour
{   
    public Transform tpOut1;
    public Transform tpOut2;
    public Transform tpOut3;
    public Transform tpOut4;

    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal3;
    public GameObject portal4;

    public MeshRenderer portal2Mesh;
    public MeshCollider portal2Collider;
    public MeshRenderer portal4Mesh;
    public MeshCollider portal4Collider;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(portalSwitch());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.name == "Portal 1")
            {
                gameObject.transform.position = portal2.gameObject.transform.position;
                //transform.rotation = portal1.transform.rotation;
                //transform.Rotate(new Vector3(0,180,0));
            }
            if (other.gameObject.name == "Portal 2")
            {
                gameObject.transform.position = tpOut1.position;
                //transform.rotation = portal1.transform.rotation;
                //transform.Rotate(new Vector3(0,180,0));
            }

            if (other.gameObject.name == "Portal 3")
            {
                gameObject.transform.position = tpOut4.position;
            }
            if (other.gameObject.name == "Portal 4")
            {
                gameObject.transform.position = tpOut3.position;
            }
    }
    
    private IEnumerator portalSwitch()
    {   
        while (true)
        {
            yield return new WaitForSeconds(3f); 
            portal2Mesh.enabled = false;
            portal2Collider.enabled = false;
            portal4Mesh.enabled = true;
            portal4Collider.enabled = true;
            yield return new WaitForSeconds(3f);
            portal2Mesh.enabled = true;
            portal2Collider.enabled = true;
            portal4Mesh.enabled = false;
            portal4Collider.enabled = false;
        }
    }
}
