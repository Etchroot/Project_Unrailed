using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Rail : MonoBehaviour
{
    StackRailroad train;
    XRGrabInteractable xRGrabInteractable;
    Rigidbody rig;
    private void Awake()
    {
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
        rig = GetComponent<Rigidbody>();
    }
    private void Start()
    {

        xRGrabInteractable.selectEntered.AddListener((param1) =>
        {
            Grabed(param1);

        });
    }

    private void Grabed(SelectEnterEventArgs param1)
    {
        Debug.Log(param1);

        Grabed();
    }

    public void Train(StackRailroad stackRailroad)
    {
        train = stackRailroad;
    }

    public void Grabed()
    {
        train.TakeRail(this.gameObject);
        rig.constraints = RigidbodyConstraints.None;
        this.gameObject.transform.parent = null;
    }
}
