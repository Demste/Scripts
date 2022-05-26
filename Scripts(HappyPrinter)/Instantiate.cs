using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Instantiate : MonoBehaviour
{
    public GameObject[] prefs;
    private float x = 1f;

    public void TrueLetterCube() 
    {

        Vector3 pos = new Vector3(x, 0f, 0f);       
       
        Instantiate(prefs[0], pos, Quaternion.identity);
        x++;
    }
    public void FalseLetterCube()
    {

        Vector3 pos = new Vector3(x, 0f, 0f);
        GameObject clone;
        clone= Instantiate(prefs[1], pos, Quaternion.identity);
        clone.transform.DOMoveY(-1,5f);
        clone.transform.DOScale(Vector3.zero,1.5f);
        //clone.GetComponent<MeshRenderer>().material.DOFade(1f, 1f);

    }
}
