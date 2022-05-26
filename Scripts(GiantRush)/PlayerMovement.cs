using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public float forwardSpeed, sideSpeed;
    private float ınputx;
    private bool ground;
    private Vector3 downVel;


    Vector3 firstpos = new Vector3(0f, 0f, 0f);
    Vector3 lastpos = new Vector3(0f, 0f, 0f);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstpos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            ınputx = Input.GetAxis("Mouse X") * 20;

            lastpos = Input.mousePosition;

            Vector2 dir = (lastpos - firstpos);
            dir.x = Mathf.Clamp(dir.x / 10f, -45, 45);
            Vector3 dire = new Vector3(0f, dir.x, 0f);
            //transform.DORotate(dire, 0.1f);

        }
        if (ground)
        {
            downVel = new Vector3(0f, 0f, 0f);
        }
        else
        {
            downVel = new Vector3(0f, -5f, 0f);
        }
    }

    private void FixedUpdate()
    {
        Vector3 forwardMovement = transform.forward * forwardSpeed;

        Vector3 sideMovement = transform.right * ınputx * sideSpeed;
        Vector3 movementVelocity = forwardMovement + sideMovement;


        rb.velocity = sideMovement + forwardMovement + downVel;
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }
    }
    private void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = false;
        }
    }

}
