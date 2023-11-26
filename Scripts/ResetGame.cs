using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public int sceneToLoad;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           //Debug.Log("sceneBuildIndex to load: " + sceneToLoad);
           //SceneManager.LoadScene(sceneToLoad);
           
           GameManager.instance.Respawn();
            //SceneManager.LoadScene(sceneToLoad);
        }
    }
}
