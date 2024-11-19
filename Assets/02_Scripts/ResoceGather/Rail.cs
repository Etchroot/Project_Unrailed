using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Rail : MonoBehaviour
{
    StackRailroad train;
    XRGrabInteractable xRGrabInteractable;
    private void Awake()
    {
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
    }
    private void Start()
    {

        xRGrabInteractable.selectEntered.AddListener((param1) =>
        {
            Grabed();

        });
    }
    public void Train(StackRailroad stackRailroad)
    {
        train = stackRailroad;
    }

    public void Grabed()
    {
        train.TakeRail(this.gameObject);
    }
}
