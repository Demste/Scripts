using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rendererr : MonoBehaviour
{
    public float fadespeed;
    public Renderer materf;

    void Start()
    {
        materf = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(FadeinObj());
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(FadeoutObj());

        }

    }
    public IEnumerator FadeoutObj()
    {
        while (materf.material.color.a > 0f)
        {
           
            Color objcolor = materf.material.color;
            float fadeamount = objcolor.a - (fadespeed * Time.deltaTime);

            objcolor = new Color(objcolor.r, objcolor.g, objcolor.b, fadeamount);
            materf.material.color = objcolor;

            yield return null;

        }
    }
    public IEnumerator FadeinObj() 
    {
        while (materf.material.color.a < 1f) 
        {
            
            Color objcolor = materf.material.color;
            float fadeamount = objcolor.a + (fadespeed * Time.deltaTime);

            objcolor = new Color(objcolor.r,objcolor.g,objcolor.b,fadeamount);
            materf.material.color = objcolor;

            yield return null;

        }
    }

}
