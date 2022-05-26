using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private string currentAnimaton;

    [HideInInspector]
    public string lastAnim;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    public void ChangeAnimationState(string newAnimation, float animspeed)
    {

        if (currentAnimaton == newAnimation) return;

        animator.speed = animspeed;
       // animator.CrossFade(newAnimation, 0.45f);
        animator.CrossFade(newAnimation, .2f);

        //animator.CrossFadeInFixedTime(newAnimation, 0.2f);

        //animator.Play(newAnimation);
        currentAnimaton = newAnimation;


    }
    public void AnimatorEnabled(bool b) 
    {
        animator.enabled =b;
    }



}
