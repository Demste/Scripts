using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Kick() 
    {
        anim.SetBool("Kick",true);
    }
    public void Idle() 
    {
        anim.SetBool("Kick", false);
    }
}
