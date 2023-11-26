using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPillers : MonoBehaviour
{
    public static BossPillers instance;

    public GameObject Piller;
    public int thisNumber;
    public GameObject[] cells;
    //public bool readyToGO;
    //public float waitTime = 1.0f;
    //private float timer = 0.0f;
    

    // Start is called before the first frame update
    public void Awake()
    {
                
    }

    private void Start()
    {        
      
       
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
            if (other.tag == "Boss")
            {
                 Piller.GetComponent<MeshRenderer>().enabled = false;
                 PhaseController.instance.hit[thisNumber] = true;
                            

               /* for (var i = 0; i < cells.Length; i++)
                {
                   cells[i].GetComponent<BossPillers>().hit = true;
                
                }*/
                Destroy(Piller);

             }
        if (other.tag == "Player")
        {
            Piller.GetComponent<MeshRenderer>().enabled = false;
            PhaseController.instance.hit[thisNumber] = true;


            /* for (var i = 0; i < cells.Length; i++)
             {
                cells[i].GetComponent<BossPillers>().hit = true;

             }*/
            Destroy(Piller);

        }


    }
}
