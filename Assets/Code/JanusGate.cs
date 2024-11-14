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
    
   
    Vector3 ballFillTopPosition = new Vector3();
    [SerializeField] float ballFillX;

    private GameObject UIHolderOb;
    private UIMenus GameEnd;

    void Start()
    {

        UIHolderOb = GameObject.Find("Canvas");
        GameEnd = UIHolderOb.GetComponent<UIMenus>();

        HP_Bar.fillAmount = Gate_HP / 1000f;
        ballFillTopTransform = fillEnding.GetComponent<Image>().rectTransform;
    }

    void LateUpdate()
    {
       
        HP_Bar.fillAmount = Gate_HP / 1000f;
        
        ballFillX += 1f;
        if (ballFillX >= 100f)
        {
            ballFillX = 0f;
        }

        ballFillTopPosition.Set(ballFillX, 0.172f * Gate_HP, 0);
        ballFillTopTransform.localPosition = ballFillTopPosition;

        if (Gate_HP >= 1000f)
        {
            Gate_HP = 1000f;
        }
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
            Debug.Log("Ends been called");
            GameEnd.End();
        }
    }

    public void IntHP()
    {
        Gate_HP += 100f;
    }
}
