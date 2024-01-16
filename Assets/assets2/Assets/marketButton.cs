using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marketButton : MonoBehaviour
{
    public bool isMarketActive;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void stopTime()
    {
        isMarketActive = true;
    }

    public void runTime()
    {
        isMarketActive = false;
    }
}
