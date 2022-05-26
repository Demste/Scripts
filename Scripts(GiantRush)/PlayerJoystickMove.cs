using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerJoystickMove : MonoBehaviour
{
    private AnimatorController anim;


    public Camera maincam;

    private CameraController camcontr;
    private BossScript bossscript;

    private Rigidbody rb;
    public float moveForce = 8f;
    public float forwardSpeed;
    private bool boss = false;


    private FixedJoystick joystick;

    void Awake()
    {

        bossscript = GetComponent<BossScript>();
        camcontr = GetComponent<CameraController>();
        anim = GetComponent<AnimatorController>();
        rb = GetComponent<Rigidbody>();
        joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    void Update()
    {
        if (transform.localScale.x==2f)
        {
            forwardSpeed += .1f;
        }
        if (transform.localScale.x == 3f)
        {
            forwardSpeed += .1f;
        }
        if (transform.localScale.x == 4f)
        {
            forwardSpeed += .1f;
        }
        if (transform.localScale.x == 5f)
        {
            forwardSpeed += .1f;
        }



        if (!boss)
        {
            rb.velocity = new Vector3(joystick.Horizontal * moveForce, rb.velocity.y, forwardSpeed * moveForce);
            transform.rotation = Quaternion.LookRotation(rb.velocity/2);
            if (rb.velocity.z > 0.1f)
            {

                anim.Run(true);
            }
        }
        if (boss)
        {
            BossFight();
           
        }

        
    }
    public void BossFight()
    {

        forwardSpeed = 0f;
        rb.velocity = Vector3.zero;
        transform.rotation = Quaternion.LookRotation(Vector3.forward);
        anim.Run(false);
        maincam.transform.DOMove(new Vector3(12f, 7.7f, 185.7f), 2f);
        maincam.transform.DORotate(new Vector3(16.7f, -83.5f, -0.022f), 2f);


        StartCoroutine(Punch());



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Boss")
        {
            boss = true;

        }
        if (other.gameObject.tag=="Up")
        {
            rb.velocity = (new Vector3(rb.velocity.x,rb.velocity.z,rb.velocity.z)) ;
        }
        if (other.gameObject.tag == "Down")
        {
            rb.velocity = (new Vector3(rb.velocity.x,rb.velocity.z-rb.velocity.z, rb.velocity.z));
        }
        if (other.gameObject.tag == "Down")
        {
            rb.velocity = (new Vector3(rb.velocity.x, rb.velocity.z -2* rb.velocity.z, rb.velocity.z));
        }

    }
    IEnumerator Punch() 
    {
        if (Input.GetMouseButtonDown(0))
        {

            anim.Punch(true);
            yield return new WaitForSeconds(1f);
            anim.Punch(false);
        }
        yield return new WaitForSeconds(2f);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            maincam.transform.DOShakeRotation(.1f,2);
            maincam.transform.DORotate(new Vector3(35.56f,-2.553f,-0.024f),.1f);
           // other.transform.DOMoveZ(other.transform.position.z + 3, 0.1f);
            //other.transform.DOKill();
        }
    }
}
