using Photon.Pun;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Resourcegrab : MonoBehaviour
{
    Rigidbody rig;
    XRGrabInteractable xrGrab;
    PhotonView photonView;
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        xrGrab = GetComponent<XRGrabInteractable>();
        photonView = GetComponent<PhotonView>();
    }
    private void Start()
    {
        xrGrab.selectEntered.AddListener((param1) =>
        {
            if (!photonView.IsMine)
            {
                photonView.RequestOwnership();
            }
        });
        xrGrab.selectExited.AddListener((param1) =>
        {
            if (photonView.IsMine)
            {
                photonView.TransferOwnership(PhotonNetwork.MasterClient);
            }
        });
    }

    [PunRPC]
    public void Doit(int v)
    {
        Debug.Log($" Log doit");
        rig.isKinematic = true;
    }
}
