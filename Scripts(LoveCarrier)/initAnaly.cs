using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using GameAnalyticsSDK;

public class initAnaly : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameAnalytics.Initialize();
        FB.Init();
    }
}
