using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceObstacle : MonoBehaviour
{
    private Rigidbody rb;
    public float power;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right*-1* power*Time.deltaTime*rb.mass);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Dead")
        {
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }


}
