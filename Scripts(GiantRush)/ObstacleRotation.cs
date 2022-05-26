using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObstacleRotation : MonoBehaviour
{
    public float timer;
    void Start()
    {
        if (transform.rotation.z == 0)
        {
            transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 90), timer);
            StartCoroutine(Sol());
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        

    }
    IEnumerator Sol() 
    {
        yield return new WaitForSeconds(1f);
        transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 0), timer);
        yield return new WaitForSeconds(1f);
        transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, -90), timer);
        yield return new WaitForSeconds(1f);
        transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 0), timer);
        yield return new WaitForSeconds(1f);
        transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 90), timer);

        StartCoroutine(Sol());


    }
}
