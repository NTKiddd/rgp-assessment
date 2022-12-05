using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{   
    private string thisScene;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        thisScene = SceneManager.GetActiveScene().name;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (thisScene == "Level 1")
                SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
            else if (thisScene == "Level 2")
                SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
        }
    }
}
