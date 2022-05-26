using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Run(bool Run)
    {
        anim.SetBool("Run", Run);
    }
    public void Punch(bool Punch)
    {
        anim.SetBool("Punch", Punch);
    }
}
