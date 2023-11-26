using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Animator anime;
    public bool onCloud = false;
    public bool floutUp;
    public float speed = .15f;
    public GameObject ThisCloud;
    public int timeToPop = 6;
    public float timetoAnime = .5f;
     


    // Update is called once per frame
    void Update()
    {

        if(onCloud)
        {
            Destroy(gameObject, timeToPop);
        }

      // Destroy(gameObject, 15);
       IsfloutingUP();
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.tag == "Player")
        {
            //anime.SetBool("OnCloud", onCloud);
            StartCoroutine(ToAnimeTrue());
            Debug.Log("OnCloud");
            onCloud = true;
            

            //RespawnCo();
        }

        
    }

    public void IsfloutingUP()
    {
        if (floutUp == true)
        { 
        ThisCloud.GetComponent<Rigidbody>().AddForce(0, speed, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CloudPooper")
        {
            Destroy(gameObject);
        }

    }

    IEnumerator ToAnimeTrue()
    {
        yield return new WaitForSeconds(timetoAnime);
        anime.SetBool("OnCloud", onCloud);


    }
    /* public IEnumerator RespawnCo()
     {

         yield return new WaitForSeconds(5f);

     }*/
}
