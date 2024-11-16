using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobObject : MonoBehaviour
{
    [SerializeField] MobObject ObTarget;
    // Start is called before the first frame update
    void Start()
    {
        ObTarget = GetComponent<MobObject>();
    }

    public void SetTarget(MobObject ObTarget)
    {
        this.ObTarget = ObTarget;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
