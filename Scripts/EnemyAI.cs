using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;
    public float moveSpeed;
    
    
    public Animator anime;
    public bool HitPlayer;
    public float ChargingPlayer;

    NavMeshAgent navMeshAgent;
   float distaceToTarget = Mathf.Infinity;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anime = gameObject.GetComponent<Animator>();
        HitPlayer = false;
        ChargingPlayer = 0;

    }

    void Update()
    {

       distaceToTarget = Vector3.Distance(target.position, transform.position);
       
        if (distaceToTarget <= chaseRange)
        {
            navMeshAgent.SetDestination(target.position);
            ChargingPlayer = moveSpeed;

            anime.SetFloat("ChargingPlayer", 1f);
        }
       
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            anime.SetBool("HitPlayer", true);
        }

    }
    public void KnockingBack()
    {
        //anime.HitPlayer = true;
        
    }

    
}
