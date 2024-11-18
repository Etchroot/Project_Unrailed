using System;
using System.Collections.Generic;
using UnityEngine;

public class StackRailroad : MonoBehaviour
{
    [SerializeField] GameObject railroad;
    [SerializeField] Transform targetposition;
    List<GameObject> LoadedRail = new();
    public void addRail()
    {
        GameObject rail = Instantiate(railroad, targetposition.position, Quaternion.identity, transform);
        LoadedRail.Add(rail);
    }

    public void TakeRail(GameObject rail)
    {
        LoadedRail.Remove(rail);
    }
}
