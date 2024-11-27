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
    GameObject target;
    PhotonView photonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            target = other.gameObject;
            photonView.RPC("Addresource", RpcTarget.All, 0);
        }
        if (other.CompareTag("Rock"))
        {
            target = other.gameObject;
            photonView.RPC("Addresource", RpcTarget.All, 1);
        }
    }

    [PunRPC]
    void Addresource(int Rtype)
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
        if (GetComponent<PhotonView>().IsMine)
            PhotonNetwork.Destroy(target);
    }

    private void Update()
    {
        if (ismaking != null) return;
        if (numofwoodlog >= spendofwood && numofstone >= spendofstone)
        {
            ismaking = StartCoroutine(MakeRailroad());
        }
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
