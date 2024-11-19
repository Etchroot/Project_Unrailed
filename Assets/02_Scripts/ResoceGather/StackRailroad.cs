using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class StackRailroad : MonoBehaviour
{
    [SerializeField] GameObject railroad;
    [SerializeField] Transform targetposition;
    List<GameObject> LoadedRail = new();
    Transform spawnpoint;
    Vector3 stackposition = new Vector3(0, 0.18f, 0);
    int numofrails = 0;
    public void AddRail()
    {
        if (LoadedRail.Count > 8)
        {
            targetposition.position += stackposition;
        }
        GameObject rail = Instantiate(railroad, targetposition.position, Quaternion.identity, transform);
        rail.GetComponent<Rail>().Train(this);
        rail.name = railroad.name + numofrails++;

        LoadedRail.Add(rail);
    }

    public void TakeRail(GameObject rail)
    {
        EditorApplication.Beep();
        LoadedRail.Remove(rail);
        if (targetposition.position.y > 6.21f)
        {
            targetposition.position -= stackposition;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log($" aabbcc");
            AddRail();
        }
    }
}
