using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] float FireBallFly = 8f;
    [SerializeField] GameObject Flame;
    [SerializeField] GameObject Boom;
    [SerializeField] GameObject Ball;

    private void Start()
    {
        Flame.SetActive(true);
        Boom.SetActive(false);
        Ball.GetComponent<SphereCollider>().radius = 0.5f;
        Ball.GetComponent<MeshRenderer>().enabled = true;
    }
    private void Update()
    {
        transform.Translate(new Vector3(0f, 0f, FireBallFly * Time.deltaTime));
        Destroy(this.gameObject, 7);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Turrain"))
        {
            FireBallFly = 0f;
            Flame.SetActive(false);
            Boom.SetActive(true);
            Ball.GetComponent<SphereCollider>().radius = 3f;
            Ball.GetComponent<MeshRenderer>().enabled = false;
            Destroy(this.gameObject, 1);
            //SphereCollider 

        }
    }
}
