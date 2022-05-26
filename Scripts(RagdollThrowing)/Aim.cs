using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Aim : MonoBehaviour
{
    private Vector2 firstpos;
    private Vector2 lastpos;
    public GameObject aim;

    public List<GameObject> players = new List<GameObject>();


    private bool isGrounded = true;
    void Start()
    {
        FindMiddlePoint();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //bölü yerinde gelcek sayı z ekseninde ne kadar çekersek oluşur


        }
        if (Input.touchCount > 0)
        {
            if (isGrounded)
            {
                aim.SetActive(true);

            }
           
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                firstpos = touch.position;

            }
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 dir = (firstpos - lastpos);
                lastpos = touch.position;
                //aim.transform.eulerAngles = new Vector3(aim.transform.eulerAngles.x, dir.x, aim.transform.eulerAngles.z);
                dir.x = Mathf.Clamp(dir.x / 10f, -90, 90);
                dir.y = Mathf.Clamp(dir.y / 10f, 0, 45);
                aim.transform.DORotate(new Vector3(dir.y * -1, dir.x, 0f), 0.1f);

                float z;
                z = Vector2.Distance(lastpos, firstpos) * 0.002f;
                z = Mathf.Clamp(z, 0.5f, 2f);

                aim.transform.DOScaleZ(z, 0.1f);

            }
            if (touch.phase == TouchPhase.Ended)
            {
                aim.SetActive(false);
                isGrounded = false;

            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag=="Ground")
        {
            isGrounded = true;
        }

    }
    public void FindMiddlePoint() 
    {

        for (int i = 0; i < players.Count; i++)
        {

            if (players[i].transform.position.x < players[i + 1].transform.position.x)
            {
                float minx = players[i].transform.position.x;
                print(minx);
            }

        }
    }
}
