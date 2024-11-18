using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerShooter : MonoBehaviour
{
   
    [SerializeField] Transform TowerAim;
    //[SerializeField] GameObject TowerOb;
    [SerializeField] NPControler Target;

    private SphereCollider Round;
    private Shot currentShot;
    [SerializeField] float FireRate;
    [SerializeField] float FireRate2;

    private void Start()
    {
        currentShot = GetComponentInChildren<Shot>();
        FireRate = currentShot.GetRateOfFire();
        Round = this.GetComponent<SphereCollider>();
    }

    public void Update()
    {
        var Targets = Physics.OverlapSphere(this.transform.parent.parent.position, Round.radius);
        var obj = Targets.FirstOrDefault(x => x.GetComponent<NPControler>()!=null);
        if (obj == null)
        {
            
            return;
        }
        Target = obj.GetComponent<NPControler>();

        if (Target != null)
        {
            

            TowerAim.transform.rotation = Quaternion.LookRotation(Target.transform.position - transform.position);

            FireRate2 -= Time.deltaTime;
            if (FireRate2 <= 0)
            {
                
                currentShot.Fire();
                FireRate2 = FireRate;
            }
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
    /*private void OnTriggerEnter(Collider other)
    {
        
        NPControler Mob = other.GetComponent<NPControler>();
        if (Mob != null)
        {
            SetTarget(Mob);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        NPControler Mob = other.GetComponent<NPControler>();
        if (Mob != null)
        {
            Target = null;
        }
    }
    public void SetTarget(NPControler newTarget)
    {
        Target = newTarget;
    }*/
}
