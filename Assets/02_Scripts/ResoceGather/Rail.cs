using System;
using Photon.Pun;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Rail : MonoBehaviour
{
    StackRailroad train;
    XRGrabInteractable xRGrabInteractable;
    Rigidbody rig;
    PhotonView photonView;
    private void Awake()
    {
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
        rig = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();
    }
    private void OnEnable()
    {
        GameObject trans2 = GameObject.Find("Train-3");
        this.transform.parent = trans2.transform;
        trans2.GetComponent<StackRailroad>().LoadedRail.Add(gameObject);
    }
    private void Start()
    {
        xRGrabInteractable.selectEntered.AddListener((param1) =>
       {
           Debug.Log($" grab");
           if (!photonView.IsMine)
           {
               photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
           }
           //    train.TakeRail(this.gameObject);
           //    rig.constraints = RigidbodyConstraints.None;
           App.Instance.isgrabedrail = true;
           PhotonNetwork.Destroy(this.gameObject);
           //    this.gameObject.transform.parent = null;
       });
        xRGrabInteractable.selectExited.AddListener((param1) =>
        {
            Debug.Log($" lease");
        });

    }



    public void Train(StackRailroad stackRailroad)
    {
        train = stackRailroad;
    }


}
