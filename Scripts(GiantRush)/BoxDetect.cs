using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetect : MonoBehaviour
{
    private BossScript bossS;
    void Start()
    {
        bossS = GetComponent<BossScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orange" || other.gameObject.tag == "Green" || other.gameObject.tag == "Yellow")
        {

            bossS.Punchy();
        }
    }
}
