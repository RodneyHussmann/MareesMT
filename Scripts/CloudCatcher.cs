using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCatcher : MonoBehaviour
{
    public GameObject cloudPoint;
    public GameObject cloud;
    public float cloudSpeed = 1f;


    public static CloudCatcher instance;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("falling");
            CloudSave();
            CloudHeath.instance.Uses();
            DialogControler.instance.Uses();
            CloudControl.instance.cloudMovespeed = 1f;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            CloudControl.instance.cloudMovespeed = 1f;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            CloudControl.instance.cloudMovespeed = .01f;
        }
    }



    void CloudSave()
    {
        Debug.Log("falling");
        cloud.transform.position = Vector3.MoveTowards(cloud.transform.position,
        cloudPoint.transform.position, cloudSpeed);

    }
}
