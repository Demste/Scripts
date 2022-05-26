using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    private Animator anim;
    public Transform player;
    private CameraController camcontr;
    public float bounce = 1f;


    private bool bars = false;

    public Image bossfilled, playerfilled;

    public GameObject Playerhealth, bosshelath;


    public float BossHealth;

    private PlayerJoystickMove jystickmove;
    public GameObject anacam, DeathCam;

    private Rigidbody rb;
    void Start()
    {

        jystickmove = GetComponent<PlayerJoystickMove>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        camcontr = GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bars)
        {
            Playerhealth.SetActive(true);
            bosshelath.SetActive(true);
        }
        if (bounce==0f)
        {
           // rb.isKinematic = true;
        }
        if (BossHealth < 0f)
        {
            Death();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Death();
        }
        if (Input.GetMouseButtonDown(0)&&Vector3.Distance(player.transform.position,transform.position)<5f)
        {
            bars = true;

            Punchy();
            BossHealth--;
            bossfilled.fillAmount = BossHealth / 10;
        }
    }
    public IEnumerator Punch() 
    {

        yield return new WaitForSeconds(1f);

        playerfilled.fillAmount= BossHealth / 10;

        anim.SetBool("Punch",true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("Punch", false);
    }
    public void Punchy() 
    {
        StartCoroutine(Punch());
    }


    public void Death() 
    {
        anacam.SetActive(false);
        DeathCam.SetActive(true);
        //DeathCam.transform.DOMove(new Vector3(0f, 7.7f, 185.7f), 2f);
        //DeathCam.transform.DORotate(new Vector3(16.7f, -2.5f, -0.022f), 2f);
        rb.AddForce(Vector3.forward *player.transform.localScale.x/25f , ForceMode.Impulse);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Untagged")
        {
            bounce--;
        }
    }
}
