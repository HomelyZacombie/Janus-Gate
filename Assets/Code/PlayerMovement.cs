using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Player movment and camara control
    [SerializeField] private Rigidbody PlayerBody;
    private Vector3 turn;
    [SerializeField] float mouseSensitivity = 1.6f;
    private Vector3 PlayerMove;
    [SerializeField] float SpeedUp = 4f;

    //Aimation controls
    private Animator PlayerAni;
    private bool WalkOn;

    //combat combo
    [SerializeField]  int comboCounter;
    [SerializeField] float cooldownTime = 0.1f;
    [SerializeField] float lastClicked;
    [SerializeField] float lastcomboEnd;
    [SerializeField] int comboLength;
    [SerializeField] float damage;
    [SerializeField] GameObject swordAtt;
    
    public UIMenus Pauseing;
    public AudioContainer Audio;
    //private bool Paused = false;

    void Start()
    {
        //Gets animator from the object this scripts attached too
        PlayerAni = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //PlayerAttBox.SetActive(false);
        WalkOn = false;
       // Audio.PlayGameAmbiant();
    }

    //Player Animations
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerAni.SetBool("IsWalking", true);
            WalkOn = true;
        }
        if (Input.GetKeyUp(KeyCode.W)) { PlayerAni.SetBool("IsWalking", false); WalkOn = false; }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerAni.SetBool("IsWalkingBack", true);

        }
        if (Input.GetKeyUp(KeyCode.S)) { PlayerAni.SetBool("IsWalkingBack", false); }
        

        if (WalkOn == true && (Input.GetKeyDown(KeyCode.LeftShift)))
        {
            PlayerAni.SetBool("IsRunning", true);
            SpeedUp = 8f;
        }
        if (WalkOn == false || Input.GetKeyUp(KeyCode.LeftShift)) { PlayerAni.SetBool("IsRunning", false); SpeedUp = 4f; }


        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pauseing.Pause();
         
        }
       
        //Attacking animation control
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time - lastcomboEnd > cooldownTime)
        {
            
            comboCounter++;
            comboCounter = Mathf.Clamp(comboCounter, 0, comboLength);
            //Attacking();

            for(int i = 0; i < comboCounter; i++)
            {
                if(i == 0)
                {
                    if(comboCounter == 1 && PlayerAni.GetCurrentAnimatorStateInfo(0).IsTag("Movement"))
                    {
                        PlayerAni.SetBool("StartAttack", true);
                        PlayerAni.SetBool("Attack" + (i + 1), true);
                        swordAtt.GetComponent<BoxCollider>().enabled = true;
                        lastClicked = Time.time;
                        SpeedUp = 0f;
                    }
                }
                else
                {
                    
                    if (comboCounter >= (i+1) && PlayerAni.GetCurrentAnimatorStateInfo(0).IsName("Attack" + i))//IsName("Attack" +i)
                    {
                       
                        PlayerAni.SetBool("Attack" + (i + 1), true);
                        PlayerAni.SetBool("Attack" + (i), true);
                        lastClicked = Time.time;
                        SpeedUp = 0f;

                    }
                }
            }
        }

        //animation exit bool reset

        for(int i=0; i < comboLength; i++)
        {
          
            if (PlayerAni.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f && PlayerAni.GetCurrentAnimatorStateInfo(0).IsName("Attack" + (i + 1)))
            {
               
                comboCounter = 0;
                lastcomboEnd = Time.time;
                PlayerAni.SetBool("Attack" + (i + 1), false);
                PlayerAni.SetBool("StartAttack", false);
                SpeedUp = 4f;
                swordAtt.GetComponent<BoxCollider>().enabled = false;

                if (WalkOn == true && (Input.GetKeyDown(KeyCode.LeftShift)))
                {
                    PlayerAni.SetBool("IsRunning", true);
                    SpeedUp = 8f;
                }
            }
        }
    }

    //Player Movement controls
    private void FixedUpdate()
    {
        // Player rotation by mouse
        turn.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
       

        //Player movement
        PlayerMove = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
        //Input.GetAxis("Horizontal")
        MovePlayer();

    }

    private void MovePlayer()
    {
        
        Vector3 MoveVector = transform.TransformDirection(PlayerMove) * SpeedUp;
        //Player movement allowed in world from inputs
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);

    }
    
}