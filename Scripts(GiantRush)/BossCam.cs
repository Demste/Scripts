using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCam : MonoBehaviour
{
    public Transform boss;
    public Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          transform.position = new Vector3(offset.x,offset.y,boss.position.z+offset.z);
    }
}
