using System;
using System.Collections.Generic;
using UnityEngine;

public class StackRailroad : MonoBehaviour
{
    [SerializeField] GameObject railroad;
    [SerializeField] Transform targetposition;
    List<GameObject> LoadedRail = new();
    Transform spawnpoint;
    Vector3 stackposition = new Vector3(0, 0.18f, 0);
    public void addRail()
    {
        if (LoadedRail.Count > 8)
        {
            targetposition.position += stackposition;
        }
        GameObject rail = Instantiate(railroad, targetposition.position, Quaternion.identity, transform);
        LoadedRail.Add(rail);
    }

    public void TakeRail(GameObject rail)
    {
        LoadedRail.Remove(rail);
        if (targetposition.position.y > 6.21f)
        {
            targetposition.position -= stackposition;
        }
    }
}
