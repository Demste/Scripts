using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private bool oneshot = false;

    private bool finish;
    private bool lose;

    void Start()
    {
        oneshot = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!finish && !lose)
        {
            transform.position = new Vector3(player.position.x + offset.x, offset.y, player.position.z + offset.z);
        }
        if (finish )
        {
            FinishAnim();
        }
        if (lose)
        {
            LoseAnim();
        }
        finish = PlayerMove.finish;
        lose = BotMovement.finish;
        
    }
    private void FinishAnim()
    {
        if (oneshot==false)
        {
            transform.DOMove(new Vector3(transform.position.x + 2.55f, transform.position.y - .5f, transform.position.z + 4.35f), 1f);
            transform.DORotate(new Vector3(25f, transform.rotation.y - 25f, transform.rotation.z), 1f);
        }
        oneshot = true;        
    }
    private void LoseAnim() 
    {
        if (oneshot == false)
        {
            transform.DOMove(new Vector3(transform.position.x + .1f, transform.position.y - .5f, transform.position.z + 3.20f), 1f);
            transform.DORotate(new Vector3(25f, transform.rotation.y - 25f, transform.rotation.z), 1f);
        }
        oneshot = true;

    }
}
