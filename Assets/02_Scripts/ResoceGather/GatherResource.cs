using System;
using System.Collections;
using Photon.Pun;
using UnityEngine;

public class GatherResource : MonoBehaviour
{
    [SerializeField] int countofwood = 3;
    [SerializeField] int countofstone = 2;
    [SerializeField] int spendofwood = 3;
    [SerializeField] int spendofstone = 2;
    int numofwoodlog = 0;
    int numofstone = 0;
    Coroutine ismaking = null;
    [SerializeField] StackRailroad stackRailroad;
    PhotonView photonView;
    PhotonView otherPhotonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {

            photonView.RPC("Addresource", RpcTarget.All, 0);
            otherPhotonView = other.gameObject.GetComponent<PhotonView>();
            if (otherPhotonView.IsMine)
            {
                //otherPhotonView.RequestOwnership();
                PhotonNetwork.Destroy(other.gameObject);
            }
        }
        if (other.CompareTag("Rock"))
        {

            photonView.RPC("Addresource", RpcTarget.All, 1);
            otherPhotonView = other.gameObject.GetComponent<PhotonView>();
            if (otherPhotonView.IsMine)
            {
                PhotonNetwork.Destroy(other.gameObject);
                //otherPhotonView.RequestOwnership();
            }
        }
    }

    [PunRPC]
    void Addresource(int Rtype)
    {
        if (photonView.IsMine)
        {
            if (Rtype == 0)
            {
                numofwoodlog += countofwood;
                Debug.Log($" Add tree 1 log");
            }
            else if (Rtype == 1)
            {
                Debug.Log($" Add Rock 1 stone");
                numofstone += countofstone;
            }
        }
    }

    private void Update()
    {
        if (ismaking != null) return;
        if (numofwoodlog >= spendofwood && numofstone >= spendofstone)
        {
            photonView.RPC("makerailroadRPC", RpcTarget.All);
        }
    }

    [PunRPC]
    private void makerailroadRPC()
    {
        ismaking = StartCoroutine(MakeRailroad());
    }

    private IEnumerator MakeRailroad()
    {
        yield return new WaitForSeconds(2);
        numofwoodlog -= spendofwood;
        numofstone -= spendofstone;
        stackRailroad.AddRail();
        //Debug.Log($" add one rail , remain wood {numofwoodlog} , remain stone {numofstone}");
        ismaking = null;
    }

    public void addwood()
    {
        numofwoodlog += 3;
        //Debug.Log($" add woodLog , remain wood {numofwoodlog} , remain stone {numofstone}");
    }

    public void addstone()
    {
        numofstone += 2;
        //Debug.Log($" add stone , remain wood {numofwoodlog} , remain stone {numofstone}");
    }
}
