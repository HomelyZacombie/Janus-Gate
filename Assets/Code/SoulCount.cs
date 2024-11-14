using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulCount : MonoBehaviour
{
    [SerializeField] Text SoulCountText;

    public int Souls = 0;

   /* private void Start()
    {
        Souls = 0;
    }*/
    private void Update()
    {
        UpdateSoulCount();

        
    }

    public int Points
    {
        get
        {
            return Souls;
        }
        set
        {
            Souls = value;
            UpdateSoulCount();
        }
    }
    private void UpdateSoulCount()
    {
        SoulCountText.text = Souls.ToString();
       
    }
    public void TrollSoulIncrease()
    {
        Souls += 20;
       
    }
    public void GoblinSoulIncrease()
    {
        Souls += 5;
       
    }
    public void GateHPCost()
    {
        Souls -= 10;

    }
    public void TowerCost()
    {
        Souls -= 20;

    }
}
