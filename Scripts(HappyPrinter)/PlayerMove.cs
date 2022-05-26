using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    private AnimatorController anim;

    public static bool finish;
    private bool lose;

    void Start()
    {
        anim = GetComponent<AnimatorController>();
        finish = false;

        anim.Lose(false);
    }

    private void Update()
    {
        lose = BotMovement.finish;
        if (lose)
        {
            anim.Lose(true);
            StartCoroutine(RestartScene());
        }
    }

    public void Walk() 
    {

            transform.DOMoveX(transform.position.x + 1f, .3f);
            anim.Run(true);
            StartCoroutine(Idle());

    

    }
    private IEnumerator Idle() 
    {
        yield return new WaitForSeconds(0.3f);
        
        anim.Run(false);

    }

    public void Finish() 
    {
        
        if (!lose)
        {
            anim.Jump(true);
            transform.DOMoveX(transform.position.x + 3f, 1.2f);
            anim.Victory(true);
            finish = true;
            StartCoroutine(RestartScene());
        }     



        //StartCoroutine(victory());

    }
    private IEnumerator victory() 
    {

        yield return new WaitForSeconds(1f);
        transform.DOMoveX(transform.position.x + 1f, 1f);
        anim.Victory(true);
    }
    private IEnumerator RestartScene() 
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
