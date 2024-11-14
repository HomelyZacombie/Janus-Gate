using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyStones : MonoBehaviour
{
   

    [SerializeField] GameObject intText;
    private bool interactable;
    private bool InterOnce = false;
    [SerializeField] bool HoT;
    [SerializeField] GameObject Flame;

    private GameObject scriptFind;
    private JanusGate SendHP;

    public SoulCount Counter;
    [SerializeField] int amount;

    [SerializeField] GameObject Tower;

   


    private void Start()
    {
        scriptFind = GameObject.Find("Double Door Frame");
        SendHP = scriptFind.GetComponent<JanusGate>();

        Counter = FindObjectOfType<SoulCount>();

        Tower.SetActive(false);
     
    }
  
    //Determins if and when player can interact with object.
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    //checks if all the all reqerments are met to sit and stand up

    private void Update()
    {
        amount = Counter.Souls;
        if (HoT == false)
        {
            if ((interactable == true) && (InterOnce == false) && (amount >= 20))
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    InterOnce = true;
                    Flame.SetActive(true);
                    Tower.SetActive(true);
                    Counter.TowerCost();
                }
            }
        }
        if (HoT == true)
        {
            Flame.SetActive(true);
            if ((interactable == true))
            {

                if (Input.GetKeyDown(KeyCode.E) && (amount >= 10))
                {      
                    Counter.GateHPCost();
                    SendHP.IntHP();
                }
            }
        }
       


    }
}
