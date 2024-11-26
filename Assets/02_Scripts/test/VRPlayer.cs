using Photon.Pun;
using UnityEditor.Build.Content;
using UnityEngine;

public class VRPlayer : MonoBehaviour
{
    PhotonView photonView;
    Transform head;
    Transform leftHand;
    Transform rightHand;

    Transform m_camera;
    Transform leftHandController;
    Transform rightHandController;

    private void Start()
    {
        if (photonView.IsMine)
        {
            m_camera.parent = Camera.main.transform;
            leftHandController.parent = GameManager.Instance.leftcontroller.transform;
            rightHandController.parent = GameManager.Instance.rightcontroller.transform;
            head.gameObject.SetActive(false);
        }
    }
}
