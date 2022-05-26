using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public bool running = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            float z = player.transform.position.z + offset.z + player.transform.localScale.x * -2;
            if (z < -10f)
            {
                z = -10f;
            }
            float y = player.transform.position.y + offset.y + player.transform.localScale.x;
            if (y > 10f)
            {
                y = 10;
            }
            transform.position = new Vector3(offset.x, y, z);
        }
        
    }
}
