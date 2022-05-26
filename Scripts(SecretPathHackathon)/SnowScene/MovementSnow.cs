using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSnow : MonoBehaviour
{
    public float speed;
    float hmove, vmove;
    private bool onetim;


    private Vector3 obstaclevelo = new Vector3(0, 0, 0);

    public GameObject bot;
    public Rotator rt;
    public GameManage gm;

    Rigidbody rb;

    void Start()
    {
        rt.GetComponent<Rotator>();
        rb = GetComponent<Rigidbody>();
        onetim = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManage.canmove)
        {
            hmove = Input.GetAxis("Horizontal");
            vmove = Input.GetAxis("Vertical");


            Vector3 balmove = new Vector3(hmove, -1f, vmove);
             rb.velocity = (balmove * speed) + obstaclevelo;
           // rb.AddForce((balmove*speed*Time.deltaTime)+obstaclevelo);
            if (rt != null)
            {
                if (hmove != 0 || vmove != 0)
                {
                    rt.canTurn = false;
                }
                else
                {
                    rt.canTurn = true;
                }

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
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
            StartCoroutine(gm.NextScene());
            onetim = false;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            obstaclevelo = collision.gameObject.GetComponent<Rigidbody>().velocity  ;
        }

    }

}
