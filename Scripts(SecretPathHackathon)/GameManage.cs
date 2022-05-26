using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManage : MonoBehaviour
{
    public List<GameObject> roads = new List<GameObject>();
    public float fadeduration, nextblocktime;
    public string TempObject;
    public bool FadeEnable = false;

    [HideInInspector]
    public static bool canmove=false;
    void Start()
    {

        StartCoroutine(FirstFade());


       
    }
    private IEnumerator FirstFade() 
    {
        foreach (var x in roads)
        {
           
                yield return new WaitForSeconds(nextblocktime);
                x.gameObject.GetComponent<Renderer>().material.DOFade(0, fadeduration);
                FindObjectOfType<AudioManager>().PlayAudio("road");

        }


        canmove = true;
    }

    public IEnumerator NextScene() 
    {
        for (int i=roads.Count-1; i>=0 ;i--)
        {

            yield return new WaitForSeconds(0.1f);
            roads[i].gameObject.GetComponent<Renderer>().material.DOFade(1, 0.1f);
            FindObjectOfType<AudioManager>().PlayAudio("roadrev");

        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            
    }
    public IEnumerator ReplayScene() 
    {
        StartCoroutine(DoFade());
        FindObjectOfType<AudioManager>().PlayAudio("fly");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }

   /* public void DoFade()
    {
        for (int i = 0; i < roads.Count; i++)
        {
            if (TempObject==roads[i].name)
            {
                FadeEnable = true;
            }
            if (FadeEnable)
            {
                roads[i].gameObject.GetComponent<Renderer>().material.DOFade(1, 0.1f);
            }
        }
        FadeEnable = false;
    }*/
    private IEnumerator DoFade()
    {
        for (int i = 0; i < roads.Count; i++)
        {
            if (TempObject == roads[i].name)
            {
                FadeEnable = true;
            }
            if (FadeEnable)
            {
                roads[i].gameObject.GetComponent<Renderer>().material.DOFade(1, 0.1f);
            }
            yield return new WaitForSeconds(0.05f);
           // yield return null;
        }
        FadeEnable = false;
    }

}
