using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSceneS : MonoBehaviour
{
    public GameObject holdtoFast;
    public GameObject holdtoRun;
    public GameObject arrow;
    private PlayerCCont pccont;

    private void Start()
    {
        pccont = GetComponent<PlayerCCont>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            holdtoRun.SetActive(false);
            holdtoFast.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="HoldtoRun")
        {
            Time.timeScale = 0f;
            holdtoRun.SetActive(true);
            arrow.SetActive(true);

        }
        if (other.gameObject.tag == "HoldtoFast")
        {
            Time.timeScale = 0f;
            holdtoFast.SetActive(true);
            arrow.SetActive(false);

        }
    }
}
