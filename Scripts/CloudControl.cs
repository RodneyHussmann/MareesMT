using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloudControl : MonoBehaviour
{
    public GameObject cloud;
    public GameObject Player;
    public float cloudMovespeed;

    public static CloudControl instance;

    //public AudioClip[] cloudVoice;
    //AudioSource cloudAudio;

    //public int currentStatis;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        //cloudAudio = GetComponent<AudioSource>();
        

    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CloudTracking();
    }

    void CloudTracking()
    {
        
        cloud.transform.position = Vector3.MoveTowards(cloud.transform.position,
           Player.transform.position, cloudMovespeed);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(transform);
        }
    }

    

}
