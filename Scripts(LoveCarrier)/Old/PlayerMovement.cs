using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public ProgressBar pBar;

    private float touchDownStartTime;
    private float walkingSpeed = 1f;
    private float touchDownTime;
    private float barAmount;
    public float maxPlusSpeed;
    public float downgradeBarMultip;
    public float upgradeBarMultip;
    public float needHoldtoRun;

    private bool caniTouch;
    private bool can;
    private bool pressed;


    const string player_idle = "Idle";
    const string player_run = "Running";
    const string player_walk = "Walking";
    const string player_jump = "Jump";
    const string player_slide = "Slide";
    const string player_hiphopdance = "HipHopDance";

    private AnimatorController animcont;


    void Start()
    {

        animcont = GetComponentInChildren<AnimatorController>();

        StartCoroutine(Walkk());
        animcont.ChangeAnimationState(player_walk, 1f);
        animcont.lastAnim = player_walk;

        can = true;
        caniTouch = true;
        pressed = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (pBar==null)
        {
            pBar = GameObject.FindObjectOfType<ProgressBar>();
            barAmount = 100f;
        }

        if (caniTouch)
        {
            if (Input.GetMouseButtonDown(0))
            {

                touchDownStartTime = Time.time;
            }


            if (Input.GetMouseButton(0))
            {
                float holdCheckTimeee = Time.time - touchDownStartTime;
                touchDownTime += Time.deltaTime * .35f;

                if (holdCheckTimeee > needHoldtoRun)
                {
                    pressed = true;

                    if (can)
                    {
                        animcont.ChangeAnimationState(player_run, 1f);
                        animcont.lastAnim = player_run;
                        can = false;
                    }
                    MoveFast();


                }
            }
            if (Input.GetMouseButtonUp(0))
            {

                animcont.ChangeAnimationState(player_walk, 1f);
                animcont.lastAnim = player_walk;
                walkingSpeed = 1f;
                can = true;
                pressed = false;

            }
        }
        if (pressed)
        {
            BarFill();
        }
        if (!pressed)
        {
            BarDown();
        }
        
       
       

    }
    private IEnumerator Walkk() 
    {
        transform.DOMoveZ(transform.position.z + walkingSpeed, 1f);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Walkk());
    }
  
    private void MoveFast() 
    {
        float plusspeed = 0f;
        plusspeed += Time.deltaTime;
        walkingSpeed += plusspeed;
        walkingSpeed = Mathf.Clamp(walkingSpeed, 0, maxPlusSpeed);
    }
    private void BarFill() 
    {
        if (pBar!=null)
        {
            barAmount -= touchDownTime * downgradeBarMultip;
            barAmount = Mathf.Clamp(barAmount, 0f, 100f);

            if (barAmount <= 0f)
            {
                Lose();

            }
            pBar.GetCurrentFill(barAmount, 100f);

        }
   

    }
    private void BarDown() 
    {
        if (pBar!=null)
        {
            barAmount += touchDownTime * upgradeBarMultip;
            barAmount = Mathf.Clamp(barAmount, 0f, 100f);
            pBar.GetCurrentFill(barAmount, 100f);
        }
     
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Jump")
        {
            //if (pressed)
            //{
            //   // transform.DOLocalMoveY(.2f, 2f);
            //    ChangeAnimationState(player_jump, 1.7f, 0f);
            //    StartCoroutine(Wait(1f));
            //}
            //if (!pressed)
            //{
            //   // transform.DOLocalMoveY(.2f, 1f);
            //    ChangeAnimationState(player_jump, 1f, 0f);
            //    StartCoroutine(Wait(1f));
            //}

            caniTouch = false;
            animcont.ChangeAnimationState(player_jump, walkingSpeed);
            StartCoroutine(WaitAfterAnim(1f));



        }
        if (other.gameObject.tag == "Slide")
        {
            caniTouch = false;
            animcont.ChangeAnimationState(player_slide, walkingSpeed);
            StartCoroutine(WaitAfterAnim(1f));
        }

    }
    private IEnumerator WaitAfterAnim(float time) 
    {
        

        yield return new WaitForSeconds(time);
        //transform.DOLocalMoveY(0.04000002f, 1f);
        animcont.ChangeAnimationState(animcont.lastAnim, 1f);
        caniTouch = true;
       

    }
    public void Lose() 
    {

        StartCoroutine(Delayi());

    }
    public void Win()
    {

        StartCoroutine(Delay());


    }
    private IEnumerator Delay() 
    {
        yield return new WaitForSeconds(1f);
        walkingSpeed = 0f;
        caniTouch = false;
        animcont.ChangeAnimationState(player_hiphopdance, 1f);

    }
    private IEnumerator Delayi()
    {
        yield return new WaitForSeconds(1f);
        walkingSpeed = 0f;
        caniTouch = false;
        animcont.AnimatorEnabled(false);

    }


}
