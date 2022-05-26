using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerThrow : MonoBehaviour
{

    private Vector3 firstpos, lastpos;
    public Rigidbody hips;
    private bool isGrounded;


    //public float forceMultiplier =100f;


    void Start()
    {

        hips = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                firstpos = touch.position;

            }
            if (touch.phase == TouchPhase.Moved)
            {
                lastpos = touch.position;

            }
            if (touch.phase == TouchPhase.Ended)
            {

                Vector2 dir = (firstpos - lastpos);
                //dir.x = Mathf.Clamp(dir.x / 10f, -90, 90);
                //alttaki hep 45derece
                dir.x = Mathf.Clamp(dir.x/1780f , -1f, 1f);
                dir.y = Mathf.Clamp(dir.y/1780f, 0f, 1f);


    

                Vector3 dire = new Vector3(dir.x,0f,dir.y*1.5f);
                //print(dire.normalized+Vector3.up);
                Relase(dire + new Vector3(0f,1.2f,0f)); ;

            }
        }
    }
    private void FixedUpdate()
    {
        
        
    }
    private void Relase(Vector3 direction) 
    {
        if (isGrounded)
        {
            hips.AddForce(direction * GameManager.forceMultiplier);
            isGrounded = false;
        }
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            isGrounded = true;
        }

    }
}
