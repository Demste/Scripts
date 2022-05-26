using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Object : MonoBehaviour
{
    private Rigidbody rb;

    public static float x, z;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       

        if (collision.gameObject.tag == this.gameObject.tag)
        {

            transform.DOPunchPosition(Vector3.up, .5f, 7, 0.5f);
            rb.isKinematic = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cylinder")
        {

            x = other.gameObject.GetComponent<Controller>().x + 0.73f;
            z = other.gameObject.GetComponent<Controller>().z;
        }
    }

}
