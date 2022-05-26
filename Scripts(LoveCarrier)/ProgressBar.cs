using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Image progressBar;

    void Start()
    {
        progressBar = GetComponent<Image>();
    }

    public void GetCurrentFill(float current,float max) 
    {
        float fillAmount = current/max;
        progressBar.fillAmount = fillAmount;
    }
}
