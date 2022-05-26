using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject player;
   // public float minAddForceDistance;
   // public float forceMultiplier;

    private Rigidbody hips;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hips = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > GameManager.minAddForceDistance)
        {
            Vector3 direction = player.transform.position - transform.position;

            hips.AddForce(direction * GameManager.forceMultiplierBot);


        }
        //if (player.transform.position.z - transform.position.z > GameManager.minAddForceDistance)
        //{
        //    Vector3 direction = player.transform.position - transform.position;

        //    hips.AddForce(direction * GameManager.forceMultiplierBot);
        //}

    }
}
