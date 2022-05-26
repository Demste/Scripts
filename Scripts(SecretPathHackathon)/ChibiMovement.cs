using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChibiMovement : MonoBehaviour
{
    public GameObject bot;
    public Rotator rt;
    public Animator anim;
    private Rigidbody rb;
    public float speed;
    public float rotationspeed;
    private bool onetim = true, oneshot = true;
    public GameManage gm;

    private Vector3 obstaclevelo = new Vector3(0, 0, 0);

    void Start()
    {
        rt.GetComponent<Rotator>();
        gm.GetComponent<GameManage>();
        anim.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManage.canmove)
        {
            float haxis = Input.GetAxisRaw("Horizontal");
            float vaxis = Input.GetAxisRaw("Vertical");
            Vector3 moveDirection = new Vector3(haxis, 0f, vaxis);
            moveDirection.Normalize();

            transform.Translate((moveDirection * speed * Time.deltaTime)+obstaclevelo, Space.World);
            if (haxis != 0 || vaxis != 0&&oneshot)
            {
               // FindObjectOfType<AudioManager>().PlayAudio("walk");
                oneshot = false;
            }
            

            if (haxis != 0 || vaxis != 0)
            {
                rt.canTurn = false;
            }
            else
            {
                rt.canTurn = true;
            }
            //rb.velocity = moveDirection * speed * Time.deltaTime;
            if (moveDirection!=Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection,Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationspeed * Time.deltaTime);


            }
            if (moveDirection.magnitude>Vector3.zero.magnitude)
            {
                anim.SetBool("walk", true);
            }
            else
            {
                anim.SetBool("walk", false);
            }



        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Help")
        {
            bot.SetActive(true);
        }
        if (other.tag == "Dead" && onetim)
        {

            GameManage.canmove = false;
            anim.SetBool("walk", false);
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
            StartCoroutine(gm.ReplayScene());
            onetim = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Finish" && onetim)
        {

            GameManage.canmove = false;
            anim.SetBool("victory", true);
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
            StartCoroutine(gm.NextScene());
            onetim = false;
        }
        if (collision.gameObject.tag=="Obstacle")
        {
            obstaclevelo = collision.gameObject.GetComponent<Rigidbody>().velocity/100;
        }
        if (collision.gameObject.tag == "Road")
        {
            gm.TempObject = collision.gameObject.name;
        }

    }
}
