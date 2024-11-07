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

    //-------------- Attack and recive damage
    //[SerializeField] int Max_HP;
    [SerializeField] float NPC_HP;
    private NPControler NPC_Code;
    private Rigidbody Freeze;
    [SerializeField] private bool IsDead = false;
    [SerializeField] private bool Attacking;
    [SerializeField] GameObject NPCAttHitBox1;
    [SerializeField] GameObject NPCAttHitBox2;

    [SerializeField] int PlayerDmg = 40;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        JanusGate = GameObject.Find("Janus Gate");
        animator = GetComponent<Animator>();

        //---------------- Attack and recive damage
        //Freeze = GetComponent<Rigidbody>();
        NPC_Code = GetComponent<NPControler>();
        //NPC_HP = Max_HP;
        Attacking = false;
        
    //agent.speed = speedWalk;
}

    // Update is called once per frame
    void Update()
    {
        DoorInAttRange = Physics.CheckSphere(transform.position, attackRange, JanusObjective);

        GoToGate();

        if (DoorInAttRange)
        {
            animator.SetBool("IsWalking", false);
            animator.SetTrigger("IsAttacking");
            agent.SetDestination(transform.position);
            NPCAttHitBox1.GetComponent<BoxCollider>().enabled = true;
            NPCAttHitBox2.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            NPCAttHitBox1.GetComponent<BoxCollider>().enabled = false;
            NPCAttHitBox2.GetComponent<BoxCollider>().enabled = false;
            DoorInAttRange = false;
            animator.SetBool("IsWalking", true);
        }
       
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (IsDead == true)
        {
            return;
        }

        if (other.CompareTag("PlayerAttacking"))
        {
            //reciveing damage
            TakeDamage(PlayerDmg);
        }
    }
    /*private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPCAttHitBox1"))
        {
            NPCAttHitBox1.GetComponent<BoxCollider>().enabled = false;
        }
        if (other.CompareTag("NPCAttHitBox2"))
        {
            NPCAttHitBox2.GetComponent<BoxCollider>().enabled = false;
        }
    }*/


    private void TakeDamage(float amount)
    {
        NPC_HP -= amount;

        if (NPC_HP <= 0)
        {
            StopAllCoroutines();
            IsDead = true;
            NPCAttHitBox1.GetComponent<BoxCollider>().enabled = false;
            animator.SetBool("IsDead", true);
            NPC_Code.enabled = false;
            agent.GetComponent<NavMeshAgent>().enabled = false;
        }
    }

    private void GoToGate()
    {
        agent.SetDestination(JanusGate.transform.position);
        
    }

    /*private void Attack()
    {
        animator.SetBool("IsWalking",false);
        animator.SetTrigger("IsAttacking");
        agent.SetDestination(transform.position);
        
    }*/

}
