using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;



public class ColorChange : MonoBehaviour
{
    [Range(0f,10f)]
    public float Value = 0f; 
    public Color color;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var main = particle.main;
        if (Value > 5)
        {
            particle.startColor = Color.Lerp(particle.startColor, Color.red, 0.5f);
           
        }
        else
        {
            particle.startColor = Color.Lerp(particle.startColor, Color.green, 0.5f);
        }
    }
}
