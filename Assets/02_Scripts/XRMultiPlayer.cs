using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class XRMultiPlayer : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] AudioListener audioListener;
    [SerializeField] TrackedPoseDriver[] trackedPoseDriver;
    [SerializeField] PhotonView photonView;
    [SerializeField] GameObject[] nearfarinteractor;
    [SerializeField] InputActionManager[] inputActionManager;
    [SerializeField] ControllerInputActionManager[] cinputActionManager;

    private void Awake()
    {
        if (!photonView.IsMine)
        {
            camera.enabled = false;
            Destroy(audioListener);
            trackedPoseDriver = GetComponentsInChildren<TrackedPoseDriver>();
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
