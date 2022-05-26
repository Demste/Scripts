using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BotMovement : MonoBehaviour
{
    private bool fast;

    private float walkingSpeed = 1f;

    public float maxPlusSpeed;

    private BotAnimatorController botanimcont;


    const string player_idle = "Idle";
    const string player_run = "Running";
    const string player_walk = "Walking";
    const string player_jump = "Jump";
    const string player_slide = "Slide";
    const string player_hiphopdance = "HipHopDance";




    void Start()
    {
        botanimcont = GetComponentInChildren<BotAnimatorController>();

        StartCoroutine(Walkk());
        botanimcont.ChangeAnimationState(player_walk, 1f);
        botanimcont.lastAnim = player_walk;

    }
    private void Update()
    {

        if (fast)
        {
            float plusspeed = 0f;
            plusspeed += Time.deltaTime;
            walkingSpeed += plusspeed;
            walkingSpeed = Mathf.Clamp(walkingSpeed, 0, maxPlusSpeed);
        }
        if (!fast && walkingSpeed>1f)
        {
            float plusspeed = 0f;
            plusspeed += Time.deltaTime;
            walkingSpeed -= plusspeed;
            walkingSpeed = Mathf.Clamp(walkingSpeed, 1, maxPlusSpeed);

        }


    }

    private IEnumerator Walkk()
    {
        transform.DOMoveZ(transform.position.z + walkingSpeed, 1f);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Walkk());
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jump")
        {
            // transform.DOLocalMoveY(.2f, 2f);
            botanimcont.ChangeAnimationState(player_jump, walkingSpeed);
            StartCoroutine(WaitAfterAnim(1f));
        }
        if (other.gameObject.tag == "Slide")
        {
            // transform.DOLocalMoveY(.2f, 2f);
            botanimcont.ChangeAnimationState(player_slide, walkingSpeed);
            StartCoroutine(WaitAfterAnim(1f));
        }
        if (other.gameObject.tag=="Fast")
        {
            fast = true;
            SpeedUp();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fast")
        {
            fast = false;
            SpeedDown();
        }
    }
    private IEnumerator WaitAfterAnim(float time)
    {

        yield return new WaitForSeconds(time);
        //transform.DOLocalMoveY(0.04000002f, 1f);
        botanimcont.ChangeAnimationState(botanimcont.lastAnim, 1f);


    }

    private void SpeedUp() 
    {
        botanimcont.ChangeAnimationState(player_run,1f);
        botanimcont.lastAnim = player_run;

    }
    private void SpeedDown()
    {
        botanimcont.ChangeAnimationState(player_walk, 1f);
        botanimcont.lastAnim = player_walk;

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
        botanimcont.ChangeAnimationState(player_hiphopdance, 1f);

    }
    private IEnumerator Delayi()
    {
        yield return new WaitForSeconds(1f);
        walkingSpeed = 0f;
        botanimcont.AnimatorEnabled(false);

    }

}
