using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotator : MonoBehaviour
{
    [HideInInspector]
    public bool canTurn = true;
    public float turningspeed;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canTurn&&GameManage.canmove==true)
        {
            transform.Rotate(0, turningspeed, 0);
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }
        
        

    }
}
