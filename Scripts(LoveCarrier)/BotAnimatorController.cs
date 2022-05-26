using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BotAnimatorController : MonoBehaviour
{
    private Animator botanimator;
    private string currentAnimaton;

    [HideInInspector]
    public string lastAnim;



    void Awake()
    {
        botanimator = GetComponent<Animator>();
    }

    public void ChangeAnimationState(string newAnimation, float animspeed)
    {


        if (currentAnimaton == newAnimation) return;

        botanimator.speed = animspeed;
        botanimator.CrossFade(newAnimation, .2f);

        //animator.CrossFadeInFixedTime(newAnimation, 0.2f);

        // animator.Play(newAnimation);
        currentAnimaton = newAnimation;


    }
    public void AnimatorEnabled(bool b)
    {
        botanimator.enabled = b;
    }



}

