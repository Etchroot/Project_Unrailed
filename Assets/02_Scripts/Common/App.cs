using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

//public enum <> {}

public class App : Singleton<App>
{
    public NearFarInteractor rightnearFarInteractor;

    public List<int> pathofRails;
}
