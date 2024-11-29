using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance = null;
    public Transform xrorigin;
    public GameObject leftcontroller;
    public GameObject rightcontroller;
    GameObject player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

    }

    void Start()
    {
        Vector3 pos = new Vector3(Random.Range(34, 44), 3.2f, Random.Range(9, 26));
        player = PhotonNetwork.Instantiate("VrPlyaer", pos, transform.rotation, 0);
        xrorigin.transform.position = pos;
        xrorigin.transform.rotation = transform.rotation;

    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(player);
    }



}
