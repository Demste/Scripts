using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovementCont : MonoBehaviour
{


    private BotAnimatorController anim;
    //private string lastAnim;
   // private string currentAnimaton;

    CharacterController characterController;

    //public BotAnimatorController botanimCont;

    private bool canigo;
    private bool groundedPlayer;
    private bool fast;


    public float maxPlusSpeed;
    public float jumpHeight;
    private float gravityValue = -9.81f;
    public float speed;
    public float defaultSpeed;

    private Vector3 playerVelocity;

    private GameMan gameman;


    const string player_idle = "Idle";
    const string player_run = "Running";
    const string player_walk = "Walking";
    const string player_jump = "Jump";
    const string player_slide = "Slide";
    const string player_hiphopdance = "HipHopDance";
    const string player_mudwalking = "Mud";
    const string player_crawling = "Crawling";
    const string player_win = "Win";





    void Start()
    {
        gameman = GameObject.Find("GameMan").GetComponent<GameMan>();
        anim = GetComponentInChildren<BotAnimatorController>();
        characterController = GetComponent<CharacterController>();
        anim.ChangeAnimationState(player_idle, 1f);
        anim.lastAnim = player_walk;

        canigo = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && GameMan.botWin == false && GameMan.playerWin == false)
        {
            if (!canigo)
            {
                canigo = true;
                anim.ChangeAnimationState(player_walk,1f);
                anim.lastAnim = player_walk;
            }
        }
        if (canigo)
        {
            if (fast)
            {

                MoveFast();
            }
            if (!fast && speed > 1f)
            {
                //float plusspeed = 0f;
                //plusspeed += Time.deltaTime;
                //speed -= plusspeed;
                //speed = Mathf.Clamp(speed, 1, maxPlusSpeed);
                MoveDown();

            }


            MovingForever();
        }        
               

    }
    private void MovingForever()
    {

        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {

            playerVelocity.y = 0f;
        }

        Vector3 move = Vector3.forward;
        characterController.Move(move * Time.deltaTime * speed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;       
        characterController.Move(playerVelocity * Time.deltaTime);
    }
    private void MoveFast()
    {

        float plusspeed = 0f;
        plusspeed += Time.deltaTime;
        speed += plusspeed;
        speed = Mathf.Clamp(speed, 0, maxPlusSpeed);
    }
    private void MoveDown()
    {
        float plusspeed = 0f;
        plusspeed += Time.deltaTime;
        speed -= plusspeed;
        speed = Mathf.Clamp(speed, defaultSpeed, maxPlusSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Fast")
        {

            fast = true;
            SpeedUp();
        }
        if (other.gameObject.tag == "Jump")
        {
            
            if (fast)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                //0.8f ti
                anim.ChangeAnimationState(player_jump, .8f);

            }
            else
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                anim.ChangeAnimationState(player_jump, .7f);

            }


        }
        if (other.gameObject.tag == "Slide")
        {
           
            if (fast)
            {
                //playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                anim.ChangeAnimationState(player_slide, .7f);

            }
            else
            {
                //playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                anim.ChangeAnimationState(player_slide, 1f);

            }

        }
        if (other.gameObject.tag == "Mud")
        {
           
            maxPlusSpeed -= 2f;
            defaultSpeed -= 1.5f;
            if (fast)
            {

                anim.ChangeAnimationState(player_mudwalking, 1f);
            }
            else
            {
                anim.ChangeAnimationState(player_mudwalking, .5f);

            }
        }
        if (other.gameObject.tag == "Crawling")
        {

            if (fast)
            {

                anim.ChangeAnimationState(player_crawling, .8f);
            }
            else
            {

                anim.ChangeAnimationState(player_crawling, .7f);
            }


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fast")
        {
            fast = false;
            SpeedDown();
        }
        if (other.gameObject.tag == "Mud")
        {
            defaultSpeed += 1.5f;
            maxPlusSpeed += 2f;
   
            StartCoroutine(WaitAfterAnim(.1f));

        }
        if (other.gameObject.tag == "Crawling")
        {

            StartCoroutine(WaitAfterAnim(.1f));


        }
        if (other.gameObject.tag == "Jump")
        {
           
            StartCoroutine(WaitAfterAnim(.1f));

        }
        if (other.gameObject.tag == "Slide")
        {

            StartCoroutine(WaitAfterAnim(.1f));
        }

    }
    private void SpeedUp()
    {
        anim.ChangeAnimationState(player_run, 1f);
        anim.lastAnim = player_run;

    }
    private void SpeedDown()
    {
        anim.ChangeAnimationState(player_walk, 1f);
        anim.lastAnim = player_walk;

    }

    private IEnumerator WaitAfterAnim(float time)
    {
        yield return new WaitForSeconds(time);
        //transform.DOLocalMoveY(0.04000002f, 1f);
        anim.ChangeAnimationState(anim.lastAnim, 1f);

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
        speed = 0f;
        canigo = false;

        anim.ChangeAnimationState(player_win, 1f);

    }
    private IEnumerator Delayi()
    {
        yield return new WaitForSeconds(1f);
        speed = 0f;
        canigo = false;

        anim.AnimatorEnabled(false);


    }
}

