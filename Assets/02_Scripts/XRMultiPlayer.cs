using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class XRMultiPlayer : MonoBehaviourPunCallbacks
{
    [SerializeField] Camera camera;
    [SerializeField] AudioListener audioListener;
    [SerializeField] TrackedPoseDriver[] trackedPoseDriver;
    //[SerializeField] PhotonView photonView;
    NearFarInteractor[] nearfarinteractor;
    InputActionManager[] inputActionManager;
    ControllerInputActionManager[] cinputActionManager;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        
        if (!photonView.IsMine)
        {
            camera.enabled = false;
            Destroy(audioListener);
            trackedPoseDriver = GetComponentsInChildren<TrackedPoseDriver>();
            nearfarinteractor = GetComponentsInChildren<NearFarInteractor>();
            inputActionManager = GetComponentsInChildren<InputActionManager>();
            cinputActionManager = GetComponentsInChildren<ControllerInputActionManager>();
            foreach (var item in trackedPoseDriver)
            {
                Destroy(item);
            }
            foreach (var item in nearfarinteractor)
            {
                Destroy(item);
            }
            foreach (var item in cinputActionManager)
            {
                Destroy(item);
            }
            foreach (var item in inputActionManager)
            {
                Destroy(item);
            }
        }
    }
}
