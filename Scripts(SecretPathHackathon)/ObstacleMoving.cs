using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMoving : MonoBehaviour
{
    private Rigidbody rb;
    //[SerializeField]
    private Vector3 originalPos;
    [SerializeField]
    private Vector3 finalPos;
    private Vector3 currentPos, moveDirection;
    private bool gotofinal = true;


    public float speed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPos = transform.position;
        moveDirection = finalPos - originalPos;
        moveDirection.Normalize();
        //currentPos = finalPos;
        //Move(currentPos);
    }

    private void FixedUpdate()
    {
        currentPos = transform.position;
        //rb.transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        //rb.AddForce(moveDirection*speed*Time.deltaTime);

        if (gotofinal)
        {
            moveDirection = finalPos - currentPos;
        }
        if (!gotofinal)
        {
            moveDirection = originalPos - currentPos;
        }
        if (Vector3.Distance(currentPos,finalPos)<0.3f)
        {
            gotofinal = false;
            
        }
        if (Vector3.Distance(currentPos,originalPos)<0.3f)
        {
            gotofinal = true;
        }
        moveDirection.Normalize();
        rb.velocity = moveDirection * speed * Time.deltaTime;
    }

    // Update is called once per frame
    /*private void Move(Vector3 pos)
    {
        transform.DOLocalMove(pos, 2f).OnComplete(()=>Move(currentPos));
        currentPos = currentPos == finalPos ? originalPos : finalPos;

    }*/
}
