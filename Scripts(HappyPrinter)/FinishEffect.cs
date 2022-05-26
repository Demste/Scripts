using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishEffect : MonoBehaviour
{
    public GameObject effect;
    public GameObject effect2;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {

            effect.SetActive(true);
            effect2.SetActive(true);
        }
    }
}
