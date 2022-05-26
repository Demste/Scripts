using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Controller : MonoBehaviour
{
   // public GameObject[] objects;
    [SerializeField] private List<GameObject> Objects = new List<GameObject>();

    public static float lastTorusY;
    public static float lasTorusX, lastTorusZ;


    private JustDrag jd;
    
    public static bool correct = false;
    public static bool full = false;
   // public static bool canfly = false;
    public float x, z;


    private float finish = 0f;

    private bool firstobj = false;

    public float max;


    void Start()
    {

        StartCoroutine(Delay(1f));
        x = transform.position.x;
        z = transform.position.z;
        //jd = GetComponent<JustDrag>(); 


    }

    // Update is called once per frame
    void Update()
    {

        if (finish == 3f)
        {
            // jd.GetComponent<JustDrag>().Finish();
        }
        if (Objects.Count>1)
        {
            lastTorusY = Objects[Objects.Count - 2].transform.position.y + .8f;
        }

        



        if (max==Objects.Count)
        {
            full = true;
           // Check();
        }
        else
        {
            full = false;
        }




    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (firstobj)
        {
            if (Objects.Count < 1)
            {
                correct = true;
            }
            else
            {
                if (other.gameObject.tag == Objects[Objects.Count - 1].gameObject.tag)
                {
                    //canfly = false;
                    correct = true;
                    CorrectMatch(other.gameObject);

                }
                else
                {
                    correct = false;


                }
            }

           
            if (other.gameObject)
            {
               // canfly = false;
            }




        }

     
    }

    private void OnTriggerStay(Collider other)
    {



    }
    private void OnTriggerExit(Collider other)
    {
        RemoveObj(other.gameObject);
        if (other.gameObject)
        {
            
           // canfly = true;
            correct = false;
        }

    }




    public void CorrectMatch(GameObject obj) 
    {
        Objects.Add(obj);
    }
    public void RemoveObj(GameObject obj) 
    {
        Objects.Remove(obj);
    }


    private IEnumerator Delay(float time) 
    {
        yield return new WaitForSeconds(time);
        firstobj = true;
    }

    private void Check() 
    {
        for (int i = 0; i < Objects.Count; i++)
        {
            if (Objects[i].gameObject.tag == Objects[i+1].gameObject.tag)
            {
                finish++;

            }
            else
            {
                finish--;
            }
            
        }
    }

}
