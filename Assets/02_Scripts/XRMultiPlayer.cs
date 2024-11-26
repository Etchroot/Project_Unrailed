using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;
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
    LocomotionMediator locomotionMediator;
    Rigidbody rig;
    [SerializeField] GameObject[] locomotionmove;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {


        if (!photonView.IsMine)
        {
            camera.enabled = false;
            Destroy(audioListener);
            rig.isKinematic = true;
            foreach (var item in locomotionmove)
            {
                Destroy(item);
            }
            trackedPoseDriver = GetComponentsInChildren<TrackedPoseDriver>();
            // nearfarinteractor = GetComponentsInChildren<NearFarInteractor>();
            // inputActionManager = GetComponentsInChildren<InputActionManager>();
            cinputActionManager = GetComponentsInChildren<ControllerInputActionManager>();
            // locomotionMediator = GetComponentInChildren<LocomotionMediator>();
            foreach (var item in trackedPoseDriver)
            {
                Destroy(item);
            }
            // foreach (var item in nearfarinteractor)
            // {
            //     Destroy(item);
            // }
            foreach (var item in cinputActionManager)
            {
                Destroy(item);
            }
            // foreach (var item in inputActionManager)
            // {
            //     Destroy(item);
            // }
            // Destroy(locomotionMediator);
        }
    }
}
