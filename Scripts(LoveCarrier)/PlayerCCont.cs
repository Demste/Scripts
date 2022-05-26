using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using ElephantSDK;
using UnityEngine.SceneManagement;

public class PlayerCCont : MonoBehaviour
{
    public ProgressBar pBar;

    CharacterController characterController;

    private GameMan gameman;


    private bool canigo;
    private bool can;
    private bool pressed;
    private bool groundedPlayer;
    private bool inamin;

    public float maxPlusSpeed;
    public float jumpHeight;
    private float gravityValue = -9.81f;
    private float barAmount;
    public float speed;
    public float defaultSpeed;
    public float downgradeBarMultip;
    public float upgradeBarMultip;
    private Vector3 playerVelocity;


    private float touchDownTime = 0.8f;
    private float touchDownStartTime;
    public float needHoldtoRun;


    private AnimatorController anim;


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
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, SceneManager.GetActiveScene().name);
        Elephant.LevelStarted(SceneManager.GetActiveScene().buildIndex);
        anim = GetComponentInChildren<AnimatorController>();
        gameman = GameObject.Find("GameMan").GetComponent<GameMan>();

        characterController = GetComponent<CharacterController>();
        anim.ChangeAnimationState(player_idle,1f);
        anim.lastAnim = player_walk;
        can = true;
        canigo = false;
        pressed = false;
        barAmount = 100f;

    }

    // Update is called once per frame
    void Update()
    {
        if (pBar == null)
        {
            pBar = GameObject.FindObjectOfType<ProgressBar>();
            barAmount = 100f;
        }

        if (Input.GetMouseButtonDown(0))
        {

            touchDownStartTime = Time.time;
        }
       
       
        if (Input.GetMouseButton(0)&&canigo)
        {
            float holdCheckTimeee = Time.time - touchDownStartTime;
            //touchDownTime += Time.deltaTime * .35f;
           
       
            if (holdCheckTimeee > needHoldtoRun)
            {    
                    pressed = true;
                            
       
                if (can)
                {
                    if (!inamin)
                    {
                        anim.ChangeAnimationState(player_run, 1f);
                        
                        can = false;
                    }
                    anim.lastAnim = player_run;

                }
            }
        }
        if (Input.GetMouseButtonUp(0)&&GameMan.botWin==false&&GameMan.playerWin==false)
        {
            canigo = true;
            if (!inamin)
            {

                anim.ChangeAnimationState(player_walk, 1f);
               
                can = true;
            }
            anim.lastAnim = player_walk;
            pressed = false;

        }
       
        if (pressed && GameMan.botWin == false && GameMan.playerWin == false)
        {
            BarDown();
            MoveFast();
        }
        if (!pressed && GameMan.botWin == false && GameMan.playerWin == false)
        {
            BarFill();
            MoveDown();
        }
        if (canigo)
        {
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
    private void BarDown()
    {
        if (pBar != null)
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
    private void BarFill()
    {
        if (pBar != null)
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
            inamin = true;
            if (pressed)
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
            inamin = true;
            if (pressed)
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
        if (other.gameObject.tag=="Mud")
        {
            inamin = true;
            maxPlusSpeed -= 2f;
            defaultSpeed -= 1f;
            if (pressed)
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
            inamin = true;
            if (pressed)
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
        if (other.gameObject.tag == "Mud")
        {
            defaultSpeed += 1.5f;
            maxPlusSpeed += 2f;
            inamin = false;
            StartCoroutine(WaitAfterAnim(.1f));           

        }
        if (other.gameObject.tag == "Crawling")
        {
            inamin = false;
            StartCoroutine(WaitAfterAnim(.1f));      


        }
        if (other.gameObject.tag == "Jump")
        {
            inamin = false;
            StartCoroutine(WaitAfterAnim(.1f));

        }
        if (other.gameObject.tag == "Slide")
        {
            inamin = false;
            StartCoroutine(WaitAfterAnim(.1f));
        }

    }



    private IEnumerator WaitAfterAnim(float time)
    {
        yield return new WaitForSeconds(time);
        //transform.DOLocalMoveY(0.04000002f, 1f);
        anim.ChangeAnimationState(anim.lastAnim, 1f);

    }
    public void Lose()
    {
        GameMan.botWin = true;
        StartCoroutine(Delayi());

    }
    public void Win()
    {


        StartCoroutine(Delay());


    }
    private IEnumerator Delay()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, SceneManager.GetActiveScene().name);
        Elephant.LevelCompleted(SceneManager.GetActiveScene().buildIndex);
        yield return new WaitForSeconds(1f);
        speed = 0f;
        canigo = false;
        anim.ChangeAnimationState(player_win, 1f);
        gameman.OpenWin();

    }
    private IEnumerator Delayi()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, SceneManager.GetActiveScene().name);
        Elephant.LevelFailed(SceneManager.GetActiveScene().buildIndex);
        yield return new WaitForSeconds(1f);
        speed = 0f;


        anim.AnimatorEnabled(false);
        gameman.OpenLose();

    }
    
}

