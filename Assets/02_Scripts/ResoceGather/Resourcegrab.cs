using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Resourcegrab : MonoBehaviour
{
    Rigidbody rig;
    XRGrabInteractable xrGrab;
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        xrGrab = GetComponent<XRGrabInteractable>();
    }
    private void Start()
    {
        xrGrab.selectEntered.AddListener((param1) =>
        {
            Grabed(param1);
        });
    }

    private void Grabed(SelectEnterEventArgs param1)
    {
        rig.isKinematic = true;
    }
}
