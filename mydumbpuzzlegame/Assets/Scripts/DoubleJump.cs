using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private PlayerMovement playerMovementScript;
    private GameObject player;
    private Rigidbody Rb;
    public Color colorBlue;
    public Color colorPotato;

    private int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMovementScript = player.GetComponent<PlayerMovement>();
        Rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space) && playerMovementScript.canDoubleJump)
        {
            Rb.AddForce(Vector3.up * playerMovementScript.jumpForce, ForceMode.Impulse);
            jumpCount++;
        }

        if (jumpCount == 2)
        {
            playerMovementScript.canDoubleJump = false;
            gameObject.GetComponent<Renderer>().material.color = colorPotato;
        }
    }

    void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "DoubleJump")
        {
            playerMovementScript.canDoubleJump = true;
            playerMovementScript.canJump = false;
            gameObject.GetComponent<Renderer>().material.color = colorBlue;
            jumpCount = 0;
            Debug.Log("DoubleJump");
        }

        if (other.gameObject.tag == "Floor")
        {
            jumpCount = 0;
        }
    }
}
