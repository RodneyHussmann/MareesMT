using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour
{
    public GameObject lowerPart, BossStart, Phase1;
    public GameObject[] phases ;
    public GameObject piller1, piller2, piller3, piller4;
    //public bool[] pillersHit;
    public bool[] hit;
    //public int currentCount=0;
    public static PhaseController instance;
    public GameObject startBosBox;

    private void Update()
    {
       ChangePhase();
        //currentCount = BossPillers.instance.count;   
    }

    private void Awake()
    {
        instance = this;
        BossStart.SetActive(false);
        //Phase1.SetActive(false);
        phases[0].SetActive(false);
        phases[1].SetActive(false);

        hit[0] = false;
        hit[1] = false;
        hit[2] = false;
        hit[3] = false;
        // BossPillers.instance.count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            BossStart.SetActive(true);
            lowerPart.SetActive(false);
            phases[0].SetActive(true);
        }
    }

   public void ChangePhase()
    {


        if (hit[0]== true && hit[1] == true && hit[2]== true && hit[3] == true)
            {   
                phases[1].SetActive(true);
                phases[0].SetActive(false);
                 startBosBox.SetActive(false);
                
            }
        

       
    }
   
       
}
