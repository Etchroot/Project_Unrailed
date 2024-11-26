using Photon.Pun;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class nearfarsetter : MonoBehaviour
{
    PhotonView photonview;
    private void Awake()
    {
        photonview = GetComponentInParent<PhotonView>();
    }
    private void OnEnable()
    {
        if (photonview.IsMine)
        {
            App.Instance.rightnearFarInteractor = GetComponent<NearFarInteractor>();
        }
    }

}
