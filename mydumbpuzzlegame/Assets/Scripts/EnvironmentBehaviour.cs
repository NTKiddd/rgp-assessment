using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentBehaviour : MonoBehaviour
{
    private GameObject playerMesh;
    private PlayerMovement playermovementScript;
    private List<GameObject> jumpable = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        playerMesh = GameObject.Find("PlayerMesh");
        playermovementScript = playerMesh.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            playermovementScript.canJump = true;
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Floor"))
            playermovementScript.canJump = true;
        else if (collider.gameObject.CompareTag("Box"))
            playermovementScript.canJump = true;
    }
}
