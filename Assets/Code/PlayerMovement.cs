using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Player movment and camara control
    [SerializeField] private Rigidbody PlayerBody;
    private Vector3 turn;
    public float mouseSensitivity = 1.6f;
    private Vector3 PlayerMove;
    public static float speed = 4f;

    //Aimation controls
    private Animator PlayerAni;

    void Start()
    {
        //Gets animator from the object this scripts attached too
        PlayerAni = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerAni.SetBool("IsWalking", true);
            
        }
        if (Input.GetKeyUp(KeyCode.W)) {PlayerAni.SetBool("IsWalking", false);}

        if (Input.GetKey(KeyCode.Mouse0))
        {
            PlayerAni.SetBool("Attack", true);
            
            StartCoroutine(Attack(0.6f));
            speed = 0f;

        }

        IEnumerator Attack(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);

            PlayerAni.SetBool("Attack", false);
            speed = 4f;

        }
    }

    //Player Movement controls
    private void FixedUpdate()
    {
        // Player rotation by mouse
        turn.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
       

        //Player movement
        PlayerMove = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        MovePlayer();

    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMove) * speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);

    }
    
}