using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

   public void Run(bool Run) 
   {
        anim.SetBool("Run", Run);
   }
    public void Jump(bool Jump) 
    {
        anim.SetBool("Jump",Jump);
    }
    public void Victory(bool Victory)
    {
        anim.SetBool("Victory", Victory);
    }
    public void Lose(bool Lose)
    {
        anim.SetBool("Lose", Lose);
    }
}
