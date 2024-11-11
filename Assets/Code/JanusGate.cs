using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class JanusGate : MonoBehaviour
{
    
    [SerializeField] float Gate_HP = 1000f;
    [SerializeField] int MonsterDmg;
    // Start is called before the first frame update


    public Image HP_Bar;
    public GameObject fillEnding;
    RectTransform ballFillTopTransform;
    
    //[SerializeField] float BarFill;
    Vector3 ballFillTopPosition = new Vector3();
    [SerializeField] float ballFillX;
    //[SerializeField] float Flow = 172f;

    void Start()
    {
        //BarFill = HP_Bar.fillAmount;
        //Gate_MaxHP = HP_Bar.fillAmount * 1000f;
        HP_Bar.fillAmount = Gate_HP / 1000f;
       
        //Flow = fillEnding;


        ballFillTopTransform = fillEnding.GetComponent<Image>().rectTransform;
    }

    void LateUpdate()
    {
        //BarFill = HP_Bar.fillAmount;
        //Gate_MaxHP = HP_Bar.fillAmount * 1000f;
        HP_Bar.fillAmount = Gate_HP / 1000f;
        



        ballFillX += 1f;
        if (ballFillX >= 100f)
        {
            ballFillX = 0f;
        }

        ballFillTopPosition.Set(ballFillX, 0.172f * Gate_HP, 0);
        ballFillTopTransform.localPosition = ballFillTopPosition;
    }
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("TrollAttack"))
        {
            //reciveing damage
            TakeDamage(MonsterDmg = 10);
            

        }
        else { MonsterDmg = 0; }
        if (other.CompareTag("GoblinAttack"))
        {
            //reciveing damage
            TakeDamage(MonsterDmg = 1);
        }
        else { MonsterDmg = 0; }
    }
    private void TakeDamage(float amount)
    {
        Gate_HP -= amount;

        if (Gate_HP <= 0)
        {
           
           
            
           
            
           
        }
    }
}
