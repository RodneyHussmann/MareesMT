using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startame : MonoBehaviour
{
    public GameObject gameManager;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           

            SceneManager.LoadScene(1);
            Destroy(gameManager);
        }
    }
}
