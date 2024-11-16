using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooter : MonoBehaviour
{
   
    [SerializeField] Transform TowerAim;
    //[SerializeField] GameObject TowerOb;
    [SerializeField] NPControler Target;


    public void Update()
    {
       
        if (Target != null)
        {
            TowerAim.transform.rotation = Quaternion.LookRotation(Target.transform.position - transform.position);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy was here");

        if (other.TryGetComponent<MobObject>(out MobObject ObTarget))
        {
            Target.SetTarget(ObTarget);
            Debug.Log("Enemy was here and assigned");
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy was here");
        NPControler Mob = other.GetComponent<NPControler>();
        if (Mob != null)
        {
            SetTarget(Mob);
            Debug.Log("Enemy was here and assigned");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        NPControler Mob = other.GetComponent<NPControler>();
        if (Mob != null)
        {
            Target = null;
            Debug.Log("Enemy was here and assigned");
        }
    }
    public void SetTarget(NPControler newTarget)
    {
        Target = newTarget;
    }
}
