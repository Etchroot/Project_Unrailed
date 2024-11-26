using System;
using Photon.Pun;
using UnityEditor.Build.Content;
using UnityEngine;

public class VRPlayer : MonoBehaviour
{
    [SerializeField] PhotonView photonView;
    [SerializeField] Transform head;
    [SerializeField] Transform leftHand;
    [SerializeField] Transform rightHand;

    Transform m_camera;
    Transform leftHandController;
    Transform rightHandController;

    private void Start()
    {
        if (photonView.IsMine)
        {
            m_camera = Camera.main.transform;
            leftHandController = GameManager.Instance.leftcontroller.transform;
            rightHandController = GameManager.Instance.rightcontroller.transform;
            head.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            mapPosition(head, m_camera);
            mapPosition(leftHand, leftHandController);
            mapPosition(rightHand, rightHandController);


        }
    }

    private void mapPosition(Transform target, Transform rig)
    {
        target.position = rig.position;
        target.rotation = rig.rotation;
    }
}
