using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchToResetLocation : MonoBehaviour
{

    public GameObject SpawnPoint, player;
    //public PlayerPrefs 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, 
                SpawnPoint.transform.position, 1000f);

        }
    }
    
}
