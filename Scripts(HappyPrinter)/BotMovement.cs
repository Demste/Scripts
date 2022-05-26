using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BotMovement : MonoBehaviour
{
    private Animator anim;
    public float time;

    public GameObject[] prefs;
    private float x = 1f;
    private float z;
    public static bool finish = false;
    private bool lose = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        z = transform.position.z;
        finish = false;

        StartCoroutine(Walk());
    }
    private void Update()
    {
        lose = PlayerMove.finish;
    }

    public void TrueLetterCube()
    {

        Vector3 pos = new Vector3(x, 0f, z);

        Instantiate(prefs[0], pos, Quaternion.identity);
        x++;
    }


    private IEnumerator Walk() 
    {
        yield return new WaitForSeconds(time);
        TrueLetterCube();
        transform.DOMoveX(transform.position.x + 1f, 1f);
        anim.SetBool("Walk", true);

        yield return new WaitForSeconds(1f/1.5f);

        anim.SetBool("Walk",false);
        if (finish==false)
        {
            StartCoroutine(Walk());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Finish")
        {
            if (!lose)
            {

                anim.SetBool("Victory", true);
            }
            finish = true;

        }
    }
}
