using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kick : MonoBehaviour
{
    public GameObject camm, win;
    private float kick = 0f;
    private bool kickable = false;
    public PlayerController pc;
    private float currentTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kickable)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                currentTime += Time.deltaTime * 0.5f;


            }
            else
            {
                currentTime -= Time.deltaTime * 0.05f;
            }
        }
        if (currentTime<=0f)
        {
            currentTime = 0f;
        }
        if (currentTime>=1f)
        {
            currentTime = 1f;
        }
        if (currentTime>=0.2f)
        {
            pc.Kick();

        }
        else
        {
            pc.Idle();
        }
        if (currentTime>=0.8f)
        {
            kick += 31f;
        }
        print(kick);
        print(currentTime);
        if (kick>30f)
        {
            Winn();
        }
    }
    public void KickGame() 
    {
        win.SetActive(false);
        camm.SetActive(true);
        kickable = true;       

    }
    private void Winn() 
    {

        win.SetActive(true);
        win.transform.GetChild(2).gameObject.SetActive(false);
     
       
    }
}
