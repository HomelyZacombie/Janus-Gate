using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    [SerializeField] GameObject FireBall;
    [SerializeField] float FireRate = 4f;
    


    public float GetRateOfFire()
    {
        return FireRate;
    }
    public void Fire()
    {
       
        Instantiate(FireBall, transform.position, transform.rotation);
    }
}
