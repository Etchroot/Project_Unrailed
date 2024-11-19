using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{

    GameObject spawnedPlayerprefabs;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        spawnedPlayerprefabs = PhotonNetwork.Instantiate("XROrigin(VR)", transform.position, transform.rotation);

    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerprefabs);
    }
}
