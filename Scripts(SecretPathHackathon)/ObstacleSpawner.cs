using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private Vector3 pos;
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawntime;
    public float spawndelay;
    
    void Start()
    {
        InvokeRepeating("SpawnedObject", spawntime, spawndelay);
        
    }


    public void SpawnedObject() 
    {
        float spawnZ = Random.Range(0f, 2f);
        float spawnY = Random.Range(0f,0.5f);
        pos = new Vector3(transform.position.x, transform.position.y+ spawnY, transform.position.z+spawnZ);
        Instantiate(spawnee,pos,transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnedObject");
        }
    }
}
