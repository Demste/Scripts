using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float forceMultiplier;
    public static float minAddForceDistance;
    public static float forceMultiplierBot;
    [Header("BotSettings")]

    public  float minAddForceDistancee;
    public  float forceMultiplierBott;


    [Header("Player Settings")]

    public  float forceMultiplierr;

    void Start()
    {
        forceMultiplier = forceMultiplierr;
        minAddForceDistance = minAddForceDistancee;
        forceMultiplierBot = forceMultiplierBott;
    }

}
