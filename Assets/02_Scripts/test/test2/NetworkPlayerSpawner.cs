using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{

    GameObject spawnedPlayerprefabs;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Vector3 pos = new Vector3(Random.Range(61, 62), 3.2f, Random.Range(2, 6));
        spawnedPlayerprefabs = PhotonNetwork.Instantiate("XROrigin(VR)", pos, transform.rotation);

    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerprefabs);
    }
}
