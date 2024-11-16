using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPControler : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    private GameObject JanusGate;
   

    
    //[SerializeField] static float speedWalk = 2f;
    Vector3 walkTo;

    [SerializeField] LayerMask groundLayer, JanusObjective;
    [SerializeField] float attackRange;
    private bool DoorInAttRange;
    
    //-------------- Attack and recive damage
   
    [SerializeField] float NPC_HP;
    [SerializeField] float MaxNPC_HP; //needed for hp bar calcalation
    private NPControler NPC_Code;
    private Rigidbody Freeze;
    private bool IsDead = false;

    
    [SerializeField] GameObject NPCAttHitBox1;
    [SerializeField] GameObject NPCAttHitBox2;
    private int PlayerDmg = 40;


    //--------------- HP bar handerlers
    [SerializeField] Slider slider;
    [SerializeField] Camera PlayerCam;
    [SerializeField] Canvas NPC_UI;
    private bool NPC_UIAllow = true;
    private GameObject Player;
    //[SerializeField] Transform PosAjust;
    //[SerializeField] Vector3 offset;

    //--------------- SoulPoint Control
    [SerializeField] GameObject NPCModalName;
    private GameObject SoulPoints;
    private SoulCount Counter;
    WaveSpawner Spawner;

   // private NPControler ObTarget;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        JanusGate = GameObject.Find("Janus Gate");
        animator = GetComponent<Animator>();
        NPC_Code = GetComponent<NPControler>();
        slider.value = NPC_HP;
        NPC_UI.enabled = false;
        PlayerCam = Camera.main;
        SoulPoints = GameObject.Find("Points");
        Counter = SoulPoints.GetComponent<SoulCount>();
    }

    //public void SetTarget(NPControler ObTarget)
    //{
    //    this.ObTarget = ObTarget;
    //}
    // Update is called once per frame
    void Update()
    {
        //----------- Hb bar Handerlers
        NPC_UI.transform.rotation = PlayerCam.transform.rotation;
        slider.value = NPC_HP / MaxNPC_HP;
        //transform.position = PosAjust.position + offset;

        //----------------------------
        DoorInAttRange = Physics.CheckSphere(transform.position, attackRange, JanusObjective);

        GoToGate();

        if (DoorInAttRange)
        {
            animator.SetBool("IsWalking", false);
            animator.SetTrigger("IsAttacking");
            agent.SetDestination(transform.position);
            
        }
        else
        {
          
            DoorInAttRange = false;
            animator.SetBool("IsWalking", true);
        }
       
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            NPCAttHitBox1.GetComponent<BoxCollider>().enabled = true;
            NPCAttHitBox2.GetComponent<BoxCollider>().enabled = true;
          
        }
        else
        {
            NPCAttHitBox1.GetComponent<BoxCollider>().enabled = false;
            NPCAttHitBox2.GetComponent<BoxCollider>().enabled = false;
           
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
            if (NPC_UIAllow == true)
            {
                NPC_UI.enabled = true;
                NPC_UIAllow = false;
            }
        }
    }
    
    public void SetSpawner(WaveSpawner _spawner)
    {
        Spawner = _spawner;
    }


    private void TakeDamage(float amount)
    {
        NPC_HP -= amount;

        if (NPC_HP >= 1)
        {

        }
        if (NPC_HP <= 0)
        {
            StopAllCoroutines();
            IsDead = true;
            NPCAttHitBox1.GetComponent<BoxCollider>().enabled = false;
            animator.SetBool("IsDead", true);
            agent.GetComponent<NavMeshAgent>().enabled = false; 
            NPC_UI.enabled = false;
            NPC_Code.enabled = false;

            if(Spawner != null) Spawner.currentCreature.Remove(this.gameObject);

            if (NPCModalName.CompareTag("Troll"))
            {
                Counter.TrollSoulIncrease();
               
            }
            if (NPCModalName.CompareTag("Goblin"))
            {
                Counter.GoblinSoulIncrease();
               
            }
        }
    }

    private void GoToGate()
    {
        agent.SetDestination(JanusGate.transform.position);
        
    }
}
