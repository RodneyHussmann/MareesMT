using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform[] cloudPoint;
    
    public GameObject floutingcloud;
    public Transform Location;

    public bool ToSpawn = true;

    // Start is called before the first frame update
    public void Awake()
    {
        //instance = this;
    }

    void Update()
    {
        SpawnCloudsAtPoint();
    }


    public void SpawnCloudsAtPoint()
    {
        Location = cloudPoint[Random.Range(0, cloudPoint.Length)];

       if(ToSpawn == true)
        {
            Instantiate(floutingcloud, Location);
            ToSpawn = false;
            StartCoroutine (ToSpawnTrue());
        }


    }

    IEnumerator ToSpawnTrue()
    {
        yield return new WaitForSeconds(.5f);
        ToSpawn = true;


    }
   
}
