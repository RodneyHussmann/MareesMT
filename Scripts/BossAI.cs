using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;
    public float moveSpeed;


    public Animator anime;
    public bool IsMoving;
    public float ChargingPlayer;
    public float atkRang = 1f;
    

    public NavMeshAgent navMeshAgent;
    float distaceToTarget = Mathf.Infinity;

    public float waitCounter;
    


    public enum AIState
    {
        isMoving, isHitting, isRoaring
    };

    public AIState currentState;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //anime = gameObject.GetComponent<Animator>();
        waitCounter = 2f;
    }


    void Update()
    {
        

        switch (currentState)
        {
            case AIState.isMoving:
                ChasingPlayer();

                //anime.SetBool("IsMoving", true);

                break;

            case AIState.isHitting:
                


                break;

            case AIState.isRoaring:
               
                if (distaceToTarget >= chaseRange && waitCounter < 1 )
                {
                               
                    currentState = AIState.isRoaring;
                    anime.SetBool("IsRoaring", true);
                    anime.SetBool("IsMoving", false);
                    waitCounter = 2f;
                }

                break;
       

        }
    }



    /*private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            currentState = AIState.isHitting;
            anime.SetTrigger("Hit");
            anime.SetBool("IsMoving", false);

            navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.isStopped = true;
        }

    }*/
    public void KnockingBack()
    {
        //anime.HitPlayer = true;

    }

    public void ChasingPlayer()
    {
        distaceToTarget = Vector3.Distance(target.position, transform.position);

        if (distaceToTarget <= chaseRange)
        {
            navMeshAgent.SetDestination(target.position);
            ChargingPlayer = moveSpeed;
            currentState = AIState.isMoving;
            anime.SetBool("IsMoving", true);




        }
        
        if (distaceToTarget <= atkRang)
        {
            currentState = AIState.isHitting;
            anime.SetTrigger("Hit");
            anime.SetBool("IsMoving", false);
            anime.SetBool("IsRoaring", false);
           
            
            navMeshAgent.isStopped = true;
            waitCounter -= Time.deltaTime;
        }

        if (waitCounter >= 0 )
        {
            currentState = AIState.isMoving;
            
            navMeshAgent.isStopped = false;
        }
    }

}
