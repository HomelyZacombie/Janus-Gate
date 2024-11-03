using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPControler : MonoBehaviour
{
    private NavMeshAgent agent;
    Animator animator;

    GameObject JanusGate;

    
    //[SerializeField] static float speedWalk = 2f;
    Vector3 walkTo;

    [SerializeField] LayerMask groundLayer, JanusObjective;
    [SerializeField] float attackRange;
    [SerializeField] bool DoorInAttRange;
   
       

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        JanusGate = GameObject.Find("Janus Gate");
        animator = GetComponent<Animator>();

        //agent.speed = speedWalk;
    }

    // Update is called once per frame
    void Update()
    {
        DoorInAttRange = Physics.CheckSphere(transform.position, attackRange, JanusObjective);

        GoToGate();

        if (DoorInAttRange) Attack() ;
        else
        {

        }
      
    }

    private void GoToGate()
    {
        agent.SetDestination(JanusGate.transform.position);
        
    }

    private void Attack()
    {
        animator.SetBool("IsWalking",false);
        animator.SetTrigger("IsAttacking");
        agent.SetDestination(transform.position);
        
    }

}
