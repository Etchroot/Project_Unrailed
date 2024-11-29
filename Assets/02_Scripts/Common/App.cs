using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

//public enum <> {}

public class App : Singleton<App>
{

    public bool dev = true;
    public NearFarInteractor rightnearFarInteractor;

    public List<int> pathofRails;
    public Action traingo;
    public bool isgrabedrail = false;
    public float transpeedf_Dev = 12f;  // 6/12 = 0.5s
    public float transpeedr_Dev = 0.5f;
    public float transpeedf_test = 3f;  // 6/3 = 2s
    public float transpeedr_test = 2f;


    public float TrainSpeedF
    {
        get
        {
            if (dev)
            {
                return transpeedf_Dev;
            }
            else return transpeedf_test;
        }
    }
    public float TrainSpeedR
    {
        get
        {
            if (dev)
            {
                return transpeedr_Dev;
            }
            else return transpeedr_test;
        }
    }
}
