using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleTransform : MonoBehaviour
{
    public float firstX, lastX;
    public float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x==firstX)
        {
            transform.DOMoveX(lastX,timer);
        }
        if (transform.position.x==lastX)
        {
            transform.DOMoveX(firstX,timer);
        }
    }
}
