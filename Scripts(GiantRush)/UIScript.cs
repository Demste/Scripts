using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Transform player;
    public Transform end;
    public Image filled;
    private float distance, startDistance;
    void Start()
    {
        startDistance = Vector3.Distance(player.transform.position, end.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, end.transform.position);
        if (player.transform.position.z < end.transform.position.z)
        {
            filled.fillAmount = 1 - (distance / startDistance);
        }
    }
}
